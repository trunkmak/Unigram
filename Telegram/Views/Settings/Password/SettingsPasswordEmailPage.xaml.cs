//
// Copyright Fela Ameghino 2015-2023
//
// Distributed under the GNU General Public License v3.0. (See accompanying
// file LICENSE or copy at https://www.gnu.org/licenses/gpl-3.0.txt)
//
using Telegram.ViewModels.Settings.Password;

namespace Telegram.Views.Settings.Password
{
    public sealed partial class SettingsPasswordEmailPage : HostedPage
    {
        public SettingsPasswordEmailViewModel ViewModel => DataContext as SettingsPasswordEmailViewModel;

        public SettingsPasswordEmailPage()
        {
            InitializeComponent();
        }
    }
}
