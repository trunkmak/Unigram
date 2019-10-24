﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Td.Api;
using Template10.Common;
using Unigram.Common;
using Unigram.ViewModels;
using Unigram.Views;
using Windows.UI.Xaml;

namespace Unigram.Services
{
    public interface ISessionService : INotifyPropertyChanged
    {
        int Id { get; }
        int UserId { get; }

        bool IsActive { get; set; }

        int UnreadCount { get; }



        IProtoService ProtoService { get; }
        IEventAggregator Aggregator { get; }
    }

    public class SessionService : TLViewModelBase, ISessionService, IHandle<UpdateUnreadMessageCount>, IHandle<UpdateUnreadChatCount>, IHandle<UpdateAuthorizationState>, IHandle<UpdateConnectionState>
    {
        private readonly ILifetimeService _lifetimeService;
        private readonly int _id;

        public SessionService(int session, bool selected, IProtoService protoService, ICacheService cacheService, ISettingsService settingsService, IEventAggregator aggregator, ILifetimeService lifecycleService)
            : base(protoService, cacheService, settingsService, aggregator)
        {
            _lifetimeService = lifecycleService;
            _id = session;

            aggregator.Subscribe(this);

            IsActive = selected;

            var unreadCount = CacheService.GetUnreadCount(new ChatListMain());
            Handle(unreadCount.UnreadChatCount);
            Handle(unreadCount.UnreadMessageCount);
        }

        public int Id => _id;
        public int UserId => ProtoService.Options.MyId;

        private int _unreadCount;
        public int UnreadCount
        {
            get
            {
                return _unreadCount;
            }
            private set
            {
                Set(ref _unreadCount, value);
            }
        }

        private bool _isActive;
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                //Set(ref _isActive, value);
                _isActive = value;
                CacheService.Options.Online = value;
            }
        }

        public void Handle(UpdateUser update)
        {
            if (update.User.Id == CacheService.Options.MyId)
            {
                _lifetimeService.Update();
            }
        }

        public void Handle(UpdateUnreadMessageCount update)
        {
            if (update.ChatList is ChatListArchive)
            {
                return;
            }

            if (!Settings.Notifications.CountUnreadMessages)
            {
                return;
            }

            if (Settings.Notifications.IncludeMutedChats)
            {
                BeginOnUIThread(() => UnreadCount = update.UnreadCount, () => _unreadCount = update.UnreadCount);
            }
            else
            {
                BeginOnUIThread(() => UnreadCount = update.UnreadUnmutedCount, () => _unreadCount = update.UnreadUnmutedCount);
            }
        }

        public void Handle(UpdateUnreadChatCount update)
        {
            if (update.ChatList is ChatListArchive)
            {
                return;
            }

            if (Settings.Notifications.CountUnreadMessages)
            {
                return;
            }

            if (Settings.Notifications.IncludeMutedChats)
            {
                BeginOnUIThread(() => UnreadCount = update.UnreadCount, () => _unreadCount = update.UnreadCount);
            }
            else
            {
                BeginOnUIThread(() => UnreadCount = update.UnreadUnmutedCount, () => _unreadCount = update.UnreadUnmutedCount);
            }
        }

        #region Lifecycle

        private bool _loggingOut;

        public void Handle(UpdateAuthorizationState update)
        {
            if (update.AuthorizationState is AuthorizationStateLoggingOut)
            {
                _loggingOut = true;
            }
            else if (update.AuthorizationState is AuthorizationStateClosed && _loggingOut)
            {
                _loggingOut = false;
                _lifetimeService.Destroy(this);
            }
            else if (update.AuthorizationState is AuthorizationStateWaitPhoneNumber && !_isActive && _lifetimeService.Items.Count > 1)
            {
                ProtoService.Send(new Destroy());
            }
            else
            {
                _loggingOut = false;
            }

            //if (update.AuthorizationState is AuthorizationStateReady)
            //{
            //    _lifetimeService.Register(this);
            //}
            //else
            //{
            //    _lifetimeService.Unregister(this);
            //}

            foreach (TLWindowContext window in WindowContext.ActiveWrappers)
            {
                window.Handle(this, update);
            }
        }

        public void Handle(UpdateConnectionState update)
        {
            foreach (TLWindowContext window in WindowContext.ActiveWrappers)
            {
                window.Handle(this, update);
            }
        }

        #endregion
    }
}
