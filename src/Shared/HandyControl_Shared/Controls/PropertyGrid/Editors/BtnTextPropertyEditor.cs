using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using HandyControl.Controls;
namespace HandyControl.Controls
{
    public class BtnTextPropertyEditor : PropertyEditorBase
    {
        private Grid conGrid;

        private System.Windows.Controls.TextBox conText;

        public static event EventHandler<string> TextSelectorEvent;
        public override FrameworkElement CreateElement(PropertyItem propertyItem)
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
                Source = new BitmapImage(new Uri("pack://application:,,,/HandyControl;Component/Resources/btnview.png", UriKind.RelativeOrAbsolute)),
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
            conGrid.DataContextChanged += Grid_DataContextChanged;
            Grid.SetColumn(conText, 0);
            Grid.SetColumn(button, 2);
            return conGrid;
        }

        private void GridText_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Windows.Controls.TextBox textBox = sender as System.Windows.Controls.TextBox;
            if (textBox.Text != null && !textBox.Text.Equals(conGrid.DataContext.ToString()))
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(textBox.Text);
                conGrid.DataContext = stringBuilder;
            }
        }

        private void Grid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            conText.Text = e.NewValue.ToString();
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
    }
}
