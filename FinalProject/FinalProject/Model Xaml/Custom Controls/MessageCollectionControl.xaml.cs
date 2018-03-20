using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MessageCollectionControl.xaml
    /// </summary>
    public partial class MessageCollectionControl : UserControl
    {
        private MessageCollectionView view;
        public MessageCollectionControl()
        {
            InitializeComponent();
        }

        public MessageCollectionControl(MessageCollectionView v) : base()
        {
            view = v;
            DataContext = view;
        }
    }
}
