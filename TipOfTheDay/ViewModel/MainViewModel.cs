using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Input;

namespace TipOfTheDay.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            RefreshExecute();
        }

        #region TheTip
        private string _theTip;
        public string TheTip
        {
            get
            {
                return _theTip;
            }
            set
            {
                _theTip = value;
                RaisePropertyChanged("TheTip");
            }
        }
        #endregion

        #region Refresh
        private ICommand _refresh;
        public ICommand Refresh
        {
            get
            {
                if (_refresh == null)
                {
                    _refresh = new RelayCommand(RefreshExecute);
                }
                return _refresh;
            }
        }
        private void RefreshExecute()
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            try
            {
                TheTip = TipManager.getInstance().getRandomTip();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception found on RefreshExecute :" + ex.Message);
            }
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
        }
        #endregion

    }
}