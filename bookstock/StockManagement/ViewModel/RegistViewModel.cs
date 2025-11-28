using StockManagement.Command;
using StockManagement.Service.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StockManagement.ViewModel
{
    public class RegistViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;
        public RegistViewModel(ApiService apiService)
        {
            _apiService = apiService;
            DupEmailCommand = new RelayCommand(async() => await DuplicateCheck());
            RegistCommand = new RelayCommand(async () => await Regist());
        }
        private bool _emailReadOnly;
        public bool EmailReadOnly
        {
            get => _emailReadOnly;
            set
            {
                if (_emailReadOnly != value)
                {
                    _emailReadOnly = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string CheckPassword { get; set; }
        
        public ICommand RegistCommand { get; set; }
        public ICommand DupEmailCommand { get; set; }

        private async Task DuplicateCheck()
        {
            bool isDuplicate = await _apiService.DuplicateAsync(Email);
            if (isDuplicate)
            {
                MessageBox.Show("사용 가능한 이메일 입니다.");
                EmailReadOnly = true;

            }
            else {
                MessageBox.Show("중복된 이메일 입니다.");
            }
        }

        private async Task Regist()
        {
            if (EmailReadOnly == false) {
                MessageBox.Show("이메일 중복 확인을 해주세요!");
                return;
            }
            else if (Name == null) { 
                MessageBox.Show("이름을 작성해주세요!");
                return;
            }
            else if (Password == null) {
                MessageBox.Show("비밀번호를 작성해주세요!");
                return;
            }
            else if(Password != CheckPassword) {
                MessageBox.Show("비밀먼호가 다릅니다! 비밀번호를 확인해주세요.");
                return;
            }
            bool successe = await _apiService.RegistAsync(Email, Name, Password);
            if (successe) { MessageBox.Show("회원 가입이 완료되었습니다."); }
            else { MessageBox.Show("회원가입에 실패하였습니다. 관리자에게 문의해주세요"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
