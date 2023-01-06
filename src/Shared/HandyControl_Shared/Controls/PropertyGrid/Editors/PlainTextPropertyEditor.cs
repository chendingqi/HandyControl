using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace HandyControl.Controls
{
    public class PlainTextPropertyEditor : PropertyEditorBase
    {
        private Grid conGrid;

        private System.Windows.Controls.TextBox conText;

        public static event EventHandler<string> TextSelectorEvent;

        public override FrameworkElement CreateElement(PropertyItem propertyItem)
        {
            if (propertyItem.Description == "路径")
            {
                conGrid = new Grid
                {
                    Height = 30.0,
                    VerticalAlignment = VerticalAlignment.Top
                };
                conGrid.ColumnDefinitions.Add(new ColumnDefinition());
                conGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(2.0, GridUnitType.Pixel)
                });
                conGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(30.0, GridUnitType.Pixel)
                });
                conText = new System.Windows.Controls.TextBox
                {
                    IsReadOnly = propertyItem.IsReadOnly
                };
                conText.TextChanged += GridText_TextChanged;
                Image content = new Image
                {
                    Source = new BitmapImage(new Uri("pack://application:,,,/HandyControl;Component/Resources/FolderBottomPanel_16x.png", UriKind.RelativeOrAbsolute)),
                    Width = 16.0,
                    Height = 16.0
                };
                Button button = new Button
                {
                    Content = content,
                    Padding = new Thickness
                    {
                        Left = 2.0,
                        Top = 2.0,
                        Right = 2.0,
                        Bottom = 2.0
                    },
                    Width = 30.0,
                    Height = 30.0
                };
                button.PreviewMouseLeftButtonDown += Btn_Click;
                conGrid.Children.Add(conText);
                conGrid.Children.Add(button);
                conGrid.DataContextChanged += ConGrid_DataContextChanged;
                Grid.SetColumn(conText, 0);
                Grid.SetColumn(button, 2);
                return conGrid;
            }
            else {
                conGrid = new Grid
                {
                    Height = 30.0,
                    VerticalAlignment = VerticalAlignment.Top
                };
                conGrid.ColumnDefinitions.Add(new ColumnDefinition());
                conText = new System.Windows.Controls.TextBox
                {
                    IsReadOnly = propertyItem.IsReadOnly
                };
                conText.TextChanged += GridText_TextChanged;
                conGrid.Children.Add(conText);
                conGrid.DataContextChanged += ConGrid_DataContextChanged;
                Grid.SetColumn(conText, 0);
                return conGrid;
            }
        }

        private void ConGrid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            conText.Text = e.NewValue.ToString();
        }

        private void GridText_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Windows.Controls.TextBox textBox = sender as System.Windows.Controls.TextBox;
            if (textBox.Text != null && !textBox.Text.Equals(conGrid.DataContext.ToString()))
            {
                conGrid.DataContext = textBox.Text;
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            OnTextSelectorEvent(string.Empty);
        }

        public void OnTextSelectorEvent(string textStr)
        {
            if (TextSelectorEvent != null)
            {
                TextSelectorEvent(new object(), textStr);
            }
        }
        public override DependencyProperty GetDependencyProperty()
        {
            return FrameworkElement.DataContextProperty;
        }

        //public override DependencyProperty GetDependencyProperty() => System.Windows.Controls.TextBox.TextProperty;
    }
}
