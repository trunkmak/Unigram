﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Api.TL;
using Telegram.Api.TL.Methods.Channels;
using Telegram.Api.TL.Methods.Contacts;

namespace Telegram.Api.Services
{
    public partial interface IMTProtoService
    {
        Task<MTProtoResponse<bool>> ResetNotifySettingsAsync();
        Task<MTProtoResponse<bool>> EditChatAdminAsync(int chatId, TLInputUserBase userId, bool isAdmin);
        Task<MTProtoResponse<bool>> ReportSpamAsync(TLInputPeerBase peer);
        Task<MTProtoResponse<TLMessagesAffectedMessages>> DeleteMessagesAsync(TLVector<int> id);
        Task<MTProtoResponse<TLUserBase>> UpdateUsernameAsync(string username);
        Task<MTProtoResponse<TLUpdatesBase>> InviteToChannelAsync(TLInputChannelBase channel, TLVector<TLInputUserBase> users);
        Task<MTProtoResponse<TLUpdatesBase>> EditTitleAsync(TLChannel channel, string title);
        Task<MTProtoResponse<TLMessagesChatFull>> UpdateChannelAsync(int? channelId);
        Task<MTProtoResponse<TLContactsTopPeersBase>> GetTopPeersAsync(TLContactsGetTopPeers.Flag flags, int offset, int limit, int hash);
        Task<MTProtoResponse<TLPeerSettings>> GetPeerSettingsAsync(TLInputPeerBase peer);
        Task<MTProtoResponse<TLUpdatesBase>> ImportChatInviteAsync(string hash);
        Task<MTProtoResponse<TLUpdatesBase>> DeleteChatUserAsync(int chatId, TLInputUserBase userId);
        Task<MTProtoResponse<TLUpdatesBase>> ForwardMessageAsync(TLInputPeerBase peer, int fwdMessageId, TLMessage message);
        Task<MTProtoResponse<TLMessagesMessagesBase>> SearchGlobalAsync(string query, int offsetDate, TLInputPeerBase offsetPeer, int offsetId, int limit);
        Task<MTProtoResponse<bool>> SetInlineBotResultsAsync(bool gallery, bool pr, long queryId, TLVector<TLInputBotInlineResultBase> results, int cacheTime, string nextOffset, TLInlineBotSwitchPM switchPM);
        Task<MTProtoResponse<bool>> ReadFeaturedStickersAsync();
        Task<MTProtoResponse<TLMessagesAllStickersBase>> GetAllStickersAsync(byte[] hash);
        Task<MTProtoResponse<TLAccountPrivacyRules>> GetPrivacyAsync(TLInputPrivacyKeyBase key);
        Task<MTProtoResponse<TLPong>> PingAsync(long pingId);
        Task<MTProtoResponse<TLServerDHInnerData>> GetDHConfigAsync(int version, int randomLength);
        Task<MTProtoResponse<bool>> UpdateNotifySettingsAsync(TLInputNotifyPeerBase peer, TLInputPeerNotifySettings settings);
        Task<MTProtoResponse<TLUploadFile>> GetFileAsync(TLInputFileLocationBase location, int offset, int limit);
        Task<MTProtoResponse<bool>> BlockAsync(TLInputUserBase id);
        Task<MTProtoResponse<bool>> SetTypingAsync(TLInputPeerBase peer, bool typing);
        Task<MTProtoResponse<TLVector<TLUserBase>>> GetUsersAsync(TLVector<TLInputUserBase> id);
        Task<MTProtoResponse<TLMessagesAffectedMessages>> ReadMessageContentsAsync(TLVector<int> id);
        Task<MTProtoResponse<TLMessagesAffectedHistory>> DeleteHistoryAsync(bool justClear, TLInputPeerBase peer, int offset);
        Task<MTProtoResponse<TLMessagesDialogsBase>> GetDialogsAsync(Stopwatch timer, int offsetDate, int offsetId, TLInputPeerBase offsetPeer, int limit);
        Task<MTProtoResponse<TLAuthAuthorization>> SignUpAsync(string phoneNumber, string phoneCodeHash, string phoneCode, string firstName, string lastName);
        Task<MTProtoResponse<TLAuthAuthorization>> SignInAsync(string phoneNumber, string phoneCodeHash, string phoneCode);
        Task<MTProtoResponse<TLUpdatesDifferenceBase>> GetDifferenceAsync(int pts, int date, int qts);
        Task<MTProtoResponse<TLUpdatesBase>> MigrateChatAsync(int chatId);
        Task<MTProtoResponse<TLMessagesAffectedHistory>> DeleteUserHistoryAsync(TLChannel channel, TLInputUserBase userId);
        Task<MTProtoResponse<TLUpdatesBase>> ToggleInvitesAsync(TLInputChannelBase channel, bool enabled);
        Task<MTProtoResponse<TLMessagesDialogsBase>> GetChannelDialogsAsync(int? offset, int? limit);
        Task<MTProtoResponse<TLMessagesChatFull>> GetFullChannelAsync(TLInputChannelBase channel);
        Task<MTProtoResponse<bool>> EditAboutAsync(TLChannel channel, string about);
        Task<MTProtoResponse<TLMessagesMessagesBase>> GetMessagesAsync(TLVector<int> id);
        Task<MTProtoResponse<TLVector<TLStickerSetCovered>>> GetUnusedStickersAsync(int limit);
        Task<MTProtoResponse<bool>> HideReportSpamAsync(TLInputPeerBase peer);
        Task<MTProtoResponse<TLChatInviteBase>> CheckChatInviteAsync(string hash);
        Task<MTProtoResponse<TLUpdatesBase>> EditChatPhotoAsync(int chatId, TLInputChatPhotoBase photo);
        Task<MTProtoResponse<TLUpdatesBase>> SendMediaAsync(TLInputPeerBase inputPeer, TLInputMediaBase inputMedia, TLMessage message);
        Task<MTProtoResponse<bool>> SaveGifAsync(TLInputDocumentBase id, bool unsave);
        Task<MTProtoResponse<bool>> SaveDraftAsync(TLInputPeerBase peer, TLDraftMessageBase draft);
        Task<MTProtoResponse<TLAuthSentCode>> SendChangePhoneCodeAsync(string phoneNumber, bool? currentNumber);
        Task<MTProtoResponse<bool>> SetAccountTTLAsync(TLAccountDaysTTL ttl);
        Task<MTProtoResponse<TLPong>> PingDelayDisconnectAsync(long pingId, int disconnectDelay);
        Task<MTProtoResponse<TLPhotosPhotosBase>> GetUserPhotosAsync(TLInputUserBase userId, int offset, long maxId, int limit);
        Task<MTProtoResponse<TLPeerNotifySettingsBase>> GetNotifySettingsAsync(TLInputNotifyPeerBase peer);
        Task<MTProtoResponse<bool>> UpdateStatusAsync(bool offline);
        Task<MTProtoResponse<bool>> UnblockAsync(TLInputUserBase id);
        Task<MTProtoResponse<TLContactsContactsBase>> GetContactsAsync(string hash);
        Task<MTProtoResponse<bool>> ReadHistoryAsync(TLChannel channel, int maxId);
        Task<MTProtoResponse<bool>> UnregisterDeviceAsync(int tokenType, string token);
        Task<MTProtoResponse<bool>> DeleteAccountAsync(string reason);
        Task<MTProtoResponse<TLMessagesChats>> GetAdminedPublicChannelsAsync();
        Task<MTProtoResponse<TLUpdatesBase>> ToggleSignaturesAsync(TLInputChannelBase channel, bool enabled);
        Task<MTProtoResponse<TLMessagesMessagesBase>> GetImportantHistoryAsync(TLInputChannelBase channel, TLPeerBase peer, bool sync, int? offsetId, int? addOffset, int? limit, int? maxId, int? minId);
        Task<MTProtoResponse<TLUpdatesBase>> CreateChannelAsync(TLChannelsCreateChannel.Flag flags, string title, string about);
        Task<MTProtoResponse<TLChannelsChannelParticipants>> GetParticipantsAsync(TLInputChannelBase inputChannel, TLChannelParticipantsFilterBase filter, int offset, int limit);
        Task<MTProtoResponse<TLMessagesMessagesBase>> GetChannelHistoryAsync(string debugInfo, TLInputPeerBase inputPeer, TLPeerBase peer, bool sync, int offset, int maxId, int limit);
        Task<MTProtoResponse<bool>> ClearRecentStickersAsync(bool attached);
        Task<MTProtoResponse<bool>> UninstallStickerSetAsync(TLInputStickerSetBase stickerset);
        Task<MTProtoResponse<TLExportedChatInviteBase>> ExportChatInviteAsync(int chatId);
        Task<MTProtoResponse<TLUpdatesBase>> EditChatTitleAsync(int chatId, string title);
        Task<MTProtoResponse<TLMessagesSavedGifsBase>> GetSavedGifsAsync(int hash);
        Task<MTProtoResponse<TLUpdatesBase>> GetAllDraftsAsync();
        Task<MTProtoResponse<bool>> UpdateDeviceLockedAsync(int period);
        Task<MTProtoResponse<TLContactsResolvedPeer>> ResolveUsernameAsync(string username);
        Task<MTProtoResponse<TLAccountDaysTTL>> GetAccountTTLAsync();
        Task<MTProtoResponse<bool>> ResetAuthorizationsAsync();
        Task<MTProtoResponse<TLPhotoBase>> UpdateProfilePhotoAsync(TLInputPhotoBase id);
        Task<MTProtoResponse<bool>> SaveBigFilePartAsync(long fileId, int filePart, int fileTotalParts, byte[] bytes);
        Task<MTProtoResponse<TLUserBase>> UpdateProfileAsync(string firstName, string lastName, string about);
        Task<MTProtoResponse<TLContactsImportedContacts>> ImportContactsAsync(TLVector<TLInputContactBase> contacts, bool replace);
        Task<MTProtoResponse<TLUserFull>> GetFullUserAsync(TLInputUserBase id);
        Task<MTProtoResponse<TLContactsLink>> DeleteContactAsync(TLInputUserBase id);
        Task<MTProtoResponse<TLMessagesMessagesBase>> GetHistoryAsync(Stopwatch timer, TLInputPeerBase inputPeer, TLPeerBase peer, bool sync, int offset, int maxId, int limit);
        Task<MTProtoResponse<TLContactsFound>> SearchAsync(string q, int limit);
        Task<MTProtoResponse<bool>> LogOutAsync();
        Task<MTProtoResponse<bool>> CancelCodeAsync(string phoneNumber, string phoneCodeHash);
        Task<MTProtoResponse<TLAuthSentCode>> ResendCodeAsync(string phoneNumber, string phoneCodeHash);
        Task<MTProtoResponse<TLAccountAuthorizations>> GetAuthorizationsAsync();
        Task<MTProtoResponse<TLUpdatesChannelDifferenceBase>> GetChannelDifferenceAsync(TLInputChannelBase inputChannel, TLChannelMessagesFilterBase filter, int pts, int limit);
        Task<MTProtoResponse<TLMessagesMessageEditData>> GetMessageEditDataAsync(TLInputPeerBase peer, int id);
        Task<MTProtoResponse<TLExportedChatInviteBase>> ExportInviteAsync(TLInputChannelBase channel);
        Task<MTProtoResponse<TLUpdatesBase>> EditPhotoAsync(TLChannel channel, TLInputChatPhotoBase photo);
        Task<MTProtoResponse<TLUpdatesBase>> KickFromChannelAsync(TLChannel channel, TLInputUserBase userId, bool kicked);
        Task<MTProtoResponse<bool>> ResetTopPeerRatingAsync(TLTopPeerCategoryBase category, TLInputPeerBase peer);
        Task<MTProtoResponse<TLMessagesPeerDialogs>> GetPeerDialogsAsync(TLVector<TLInputPeerBase> peers);
        Task<MTProtoResponse<TLMessagesStickerSet>> GetStickerSetAsync(TLInputStickerSetBase stickerset);
        Task<MTProtoResponse<TLUpdatesBase>> CreateChatAsync(TLVector<TLInputUserBase> users, string title);
        Task<MTProtoResponse<TLMessage>> SendMessageAsync(TLMessage message, Action fastCallback);
        Task<MTProtoResponse<TLMessagesFoundGifs>> SearchGifsAsync(string q, int offset);
        Task<MTProtoResponse<TLMessagesBotResults>> GetInlineBotResultsAsync(TLInputUserBase bot, TLInputPeerBase peer, TLInputGeoPointBase geoPoint, string query, string offset);
        Task<MTProtoResponse<TLMessagesFeaturedStickersBase>> GetFeaturedStickersAsync(bool full, int hash);
        Task<MTProtoResponse<TLUserBase>> ChangePhoneAsync(string phoneNumber, string phoneCodeHash, string phoneCode);
        Task<MTProtoResponse<bool>> DeleteAccountTTLAsync(string reason);
        Task<MTProtoResponse<TLNearestDC>> GetNearestDCAsync();
        Task<MTProtoResponse<TLContactsBlockedBase>> GetBlockedAsync(int offset, int limit);
        Task<MTProtoResponse<TLMessagesChatFull>> GetFullChatAsync(int chatId);
        Task<MTProtoResponse<TLUpdatesDifferenceBase>> GetDifferenceWithoutUpdatesAsync(int pts, int date, int qts);
        Task<MTProtoResponse<bool>> ResetAuthorizationAsync(long hash);
        Task<MTProtoResponse<TLAccountPasswordBase>> GetPasswordAsync();
        Task<MTProtoResponse<TLAccountPasswordSettings>> GetPasswordSettingsAsync(byte[] currentPasswordHash);
        Task<MTProtoResponse<bool>> UpdatePasswordSettingsAsync(byte[] currentPasswordHash, TLAccountPasswordInputSettings newSettings);
        Task<MTProtoResponse<TLAuthorization>> CheckPasswordAsync(byte[] passwordHash);
        Task<MTProtoResponse<TLAuthPasswordRecovery>> RequestPasswordRecoveryAsync();
        Task<MTProtoResponse<TLAuthorization>> RecoverPasswordAsync(string code);
        Task<MTProtoResponse<bool>> ConfirmPhoneAsync(string phoneCodeHash, string phoneCode);
        Task<MTProtoResponse<TLAuthSentCode>> SendConfirmPhoneCodeAsync(string hash, bool currentNumber);
        Task<MTProtoResponse<TLHelpAppChangelogBase>> GetAppChangelogAsync(string deviceModel, string systemVersion, string appVersion, string langCode);
        Task<MTProtoResponse<TLHelpTermsOfService>> GetTermsOfServiceAsync(string langCode);
        Task<MTProtoResponse<TLUpdatesBase>> UpdatePinnedMessageAsync(bool silent, TLInputChannelBase channel, int id);
        Task<MTProtoResponse<bool>> CheckUsernameAsync(string username);
        Task<MTProtoResponse<TLUpdatesBase>> JoinChannelAsync(TLChannel channel);
        Task<MTProtoResponse<TLChannelsChannelParticipant>> GetParticipantAsync(TLInputChannelBase inputChannel, TLInputUserBase userId);
        Task<MTProtoResponse<TLMessagesBotCallbackAnswer>> GetBotCallbackAnswerAsync(TLInputPeerBase peer, int messageId, byte[] data, int gameId);
        Task<MTProtoResponse<TLMessage>> SendInlineBotResultAsync(TLMessage message, Action fastCallback);
        Task<MTProtoResponse<TLMessagesArchivedStickers>> GetArchivedStickersAsync(bool full, long offsetId, int limit);
        Task<MTProtoResponse<TLVector<TLWallPaperBase>>> GetWallpapersAsync();
        Task<MTProtoResponse<bool>> SaveFilePartAsync(long fileId, int filePart, byte[] bytes);
        Task<MTProtoResponse<bool>> RegisterDeviceAsync(int tokenType, string token);
        Task<MTProtoResponse<bool>> ReportPeerAsync(TLInputPeerBase peer, TLReportReasonBase reason);
        Task<MTProtoResponse<TLExportedMessageLink>> ExportMessageLinkAsync(TLInputChannelBase channel, int id);
        Task<MTProtoResponse<TLUpdatesBase>> DeleteChannelAsync(TLChannel channel);
        Task<MTProtoResponse<TLMessagesRecentStickersBase>> GetRecentStickersAsync(bool attached, int hash);
        Task<MTProtoResponse<TLMessagesStickerSetInstallResultBase>> InstallStickerSetAsync(TLInputStickerSetBase stickerset, bool archived);
        Task<MTProtoResponse<TLMessageMediaBase>> GetWebPagePreviewAsync(string message);
        Task<MTProtoResponse<TLUpdatesBase>> ForwardMessagesAsync(TLInputPeerBase toPeer, TLVector<int> id, IList<TLMessage> messages, bool withMyScore);
        Task<MTProtoResponse<TLDocumentBase>> GetDocumentByHashAsync(byte[] sha256, int size, string mimeType);
        Task<MTProtoResponse<TLAccountPrivacyRules>> SetPrivacyAsync(TLInputPrivacyKeyBase key, TLVector<TLInputPrivacyRuleBase> rules);
        Task<MTProtoResponse<TLHelpSupport>> GetSupportAsync();
        Task<MTProtoResponse<TLPhotosPhoto>> UploadProfilePhotoAsync(TLInputFile file);
        Task<MTProtoResponse<TLUpdatesState>> GetStateAsync();
        Task<MTProtoResponse<TLUpdatesBase>> ToggleChatAdminsAsync(int chatId, bool enabled);
        Task<MTProtoResponse<TLUpdatesBase>> EditMessageAsync(TLInputPeerBase peer, int id, string message, TLVector<TLMessageEntityBase> entities, TLReplyMarkupBase replyMarkup, bool noWebPage);
        Task<MTProtoResponse<TLUpdatesBase>> LeaveChannelAsync(TLChannel channel);
        Task<MTProtoResponse<TLUpdatesBase>> EditAdminAsync(TLChannel channel, TLInputUserBase userId, TLChannelParticipantRoleBase role);
        Task<MTProtoResponse<TLVector<TLStickerSetCovered>>> GetAttachedStickersAsync(TLInputStickeredMediaBase media);
        Task<MTProtoResponse<TLUpdatesBase>> AddChatUserAsync(int chatId, TLInputUserBase userId, int fwdLimit);
        Task<MTProtoResponse<TLUpdatesBase>> StartBotAsync(TLInputUserBase bot, string startParam, TLMessage message);
        Task<MTProtoResponse<bool>> ReorderStickerSetsAsync(bool masks, TLVector<long> order);
        Task<MTProtoResponse<TLVector<TLContactStatus>>> GetStatusesAsync();
        Task<MTProtoResponse<TLAuthSentCode>> SendCodeAsync(string phoneNumber, bool? currentNumber, Action<int> attemptFailed = null);
    }
}
