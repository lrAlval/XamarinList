using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Exercise.Models
{
    public class CustomCell : ViewCell
    {
        public CustomCell()
        {
            var FirstName = new Label()
            {
                HorizontalOptions = LayoutOptions.Start,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),

            };
            var Avatar = new Image();
          
            
            FirstName.SetBinding(Label.TextProperty, new Binding("FirstName"));
            Avatar.SetBinding(Image.SourceProperty, new Binding("Avatar"));

            var horizontalLayout = new StackLayout()
            {
                BackgroundColor = Color.White,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Fill
            };

            horizontalLayout.Children.Add(Avatar);
            horizontalLayout.Children.Add(FirstName);
            
            View = horizontalLayout;
        }
    }
}
