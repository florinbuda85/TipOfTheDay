using GalaSoft.MvvmLight;

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
            TheTip = TipManager.getInstance().getRandomTip();
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



    }
}