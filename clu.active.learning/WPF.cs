using System;

namespace clu.active.learning
{
    /*
    
    Windows Presentation Foundation (WPF)

    https://docs.microsoft.com/en-us/dotnet/framework/wpf/advanced/wpf-architecture

    Extensible Application Markup Language (XAML)

    It’s important to note that the XAML language itself is just a mapping of C# classes to 
    declarative code. There’s no special engine to treat XAML differently. Everything done 
    with XAML in a declarative way can be achieved with normal C# code.
    
    XAML uses a hierarchical approach to define a UI. The most common top-level element in a 
    WPF XAML file is the Window element. The Window element can include several attributes. 

    A Window element can contain a single child element that defines the content of the UI. 
    In most applications, a UI requires more than a single control, so WPF defines container 
    controls that you can use to combine other lower-level controls together and lay them out. 
    The most commonly used container control is the Grid control, and when you add a new 
    Window to a WPF project in Visual Studio, the Window template automatically adds a Grid 
    control to the Window. 

    The Grid control can contain multiple child controls that it lays out in a grid style. In 
    the example shown above, the Grid control contains a single Button control. The Grid 
    control defines a default layout that consists of a single row and a single column, but you 
    can customize this layout by defining additional rows and columns as attributes of the Grid. 
    This mechanism enables you to define cells in the Grid, and you can then place controls in 
    specific cells. You can also nest a grid control inside a cell if you need to provide finer 
    control over the layout of certain parts of a window. 

    http://go.microsoft.com/fwlink/?LinkID=267821

    The .NET Framework provides a comprehensive collection of controls that you can use to 
    implement a UI. You can find the complete set in the Toolbox that is available when you 
    design a window. You can also define your own custom user controls. The following table 
    summarizes some of the most commonly used controls: 

    Control         Description 
    Button          Displays a button that a user can click to perform an action.
    CheckBox        Enables a user to indicate whether an item should be selected (checked) or 
                    not (blank).
    ComboBox        Displays a drop-down list of items from which the user can make a selection.
    Label           Displays a piece of static text.
    ListBox         Displays a scrollable list of items from which the user can make a 
                    selection.
    RadioButton     Enables the user to select from a range of mutually exclusive options.
    TabControl      Organizes the controls in a UI into a set of tabbed pages.
    TextBlock       Displays a read-only block of text.
    TextBox         Enables the user to enter and edit text.

    */
    public static class WPF
    {
        #region Implementation

        #endregion

        #region Public Methods

        public static void SettingControlProperties()
        {
            Console.WriteLine("* Setting Control Properties");
            {
                /*

                This attribute syntax is easy to use and intuitive for developers with XML 
                experience. However, this syntax does not provide the flexibility that you need to 
                define more complex property values. 

                */
                Console.WriteLine("** Using Attributes Syntax to Set Control Properties");
                {
                    //<Button Content="Get Me a Coffee!" Background="Yellow" Foreground="Blue" />
                }

                /*
            
                Suppose that instead of setting the button background to a simple text value such as 
                Yellow, you want to apply a more complex gradient effect to the button. You cannot 
                define all the nuances of a gradient effect within an attribute value. Instead, XAML 
                supports an alternative way of setting control properties called property element 
                syntax. Rather than specifying the Background property as an inline attribute of the 
                Button element, you can add an element named Button.Background as a child element of 
                the Button element, and then in the Button.Background element, you can add further 
                child elements to define your gradient effect. 

                */
                Console.WriteLine("** Using Property Element Syntax to Set Control Properties");
                {
                    //<Button Content="Get Me a Coffee!">
                    //    <Button.Background>
                    //        <LinearGradientBrush StartPoint="0.5, 0.5" EndPoint="1.5, 1.5">
                    //            <GradientStop Color="AliceBlue" Offset="0" />
                    //            <GradientStop Color="Aqua" Offset="0.5" />
                    //        </LinearGradientBrush>
                    //    </Button.Background>
                    //    <Button.Foreground>
                    //        <SolidColorBrush Color="Yellow" />
                    //    </Button.Foreground>
                    //</Button>
                }

                /*
            
                Many WPF controls include a Content property. The previous examples used an attribute to 
                set the Content property of a button to a simple text value. However, the content of a 
                control is rarely limited to text. Instead of specifying the Content property as an 
                attribute, you can add the desired content between the opening and closing tags of the 
                control. For example, you might want to replace the contents of the Button element with 
                a picture of a cup of coffee. 

                */
                Console.WriteLine("** Adding Content to a WPF Control");
                {
                    //<Button>
                    //    <Image Source="Images/coffee.jpg" Stretch="Fill" />
                    //</Button>
                }
            }
        }

        /*
        
        When you create a WPF application in Visual Studio, each XAML page has a corresponding 
        code-behind file. For example, the MainWindow.xaml file that Visual Studio creates by default 
        has a code-behind file named MainWindow.xaml.cs. You subscribe to event handlers in your XAML 
        markup and then define your event handler logic in the code-behind file. 

        */
        public static void HandlingEvents()
        {
            Console.WriteLine("* Handling Events");
            {
                Console.WriteLine("** Handling Events in XAML");
                {
                    //<Button x:Name="btnMakeCoffee" Content="Make Me a Coffee!" Click="btnMakeCoffee_Click" />
                    //<Label x:Name="lblResult" Content="" />
                }

                Console.WriteLine("** Createing Event Handler Methods");
                {
                    //private void btnMakeCoffee_Click(object sender, RoutedEventArgs e)
                    //{
                    //    lblResult.Content = "Your coffee is on its way.";
                    //}
                }

                /*
                
                WPF uses the concept of “routed events”. When an event is raised, WPF will attempt 
                to run the corresponding event handler for the control that has the focus. If there 
                is no event handler available, then WPF will examine the parent of the control that 
                has the focus, and if it has a handler for the event it will run. If the parent has 
                no suitable event handler, WPF examines the parent of the parent, and so on right up 
                to the top-level window. This process is known as bubbling, and it enables a container 
                control to implement default event-handling logic for any events that are not handled 
                by its children. 

                When a control handles an event, the event is still bubbled to the parent in case the 
                parent needs to perform any additional processing. An event handler is passed 
                information about the event in the RoutedEventArgs parameter. An event handler can use 
                the properties in this parameter to determine the source of the event (the control that 
                had the focus when the event was raised). The RoutedEventArgs parameter also includes a 
                Boolean property called Handled. An event handler can set this property to true to 
                indicate that the event has been processed. When the event bubbles, the value of this 
                property can be used to prevent the event from being handled by a parent control. 

                */
                Console.WriteLine("** Events are Bubbled to Parent Controls");
                {
                    // https://docs.microsoft.com/en-us/dotnet/framework/wpf/advanced/routed-events-overview
                }
            }
        }

        /*
        
        Support for relative positioning is one of the core principles of WPF. The idea is that your 
        application should render correctly regardless of how the user positions or resizes the 
        application window. WPF includes several layout, or container, controls that enable you to 
        position and size your child controls in different ways. The following table shows the most 
        common layout controls: 

        Control                     Description
        Canvas                      Child controls define their own layout by specifying canvas 
                                    coordinates.
        DockPanel                   Child controls are attached to the edges of the DockPanel.
        Grid                        Child controls are added to rows and columns within the grid.
        StackPanel                  Child controls are stacked either vertically or horizontally.
        VirtualizingStackPanel      Child controls are stacked either vertically or horizontally. 
                                    At any one time, only child items that are visible on the screen 
                                    are created. 
        WrapPanel                   Child controls are added from left to right. If there are too 
                                    many controls to fit on a single line, the controls wrap to the 
                                    next line. 

        */
        public static void UsingLayoutControls()
        {
            Console.WriteLine("* Using Layout Controls");
            {
                Console.WriteLine("** Using a Canvas Layout");
                {
                    // https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.canvas?view=netframework-4.7.2
                }

                Console.WriteLine("** Using a DockPanel Layout");
                {
                    // https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.dockpanel?view=netframework-4.7.2
                }

                /*
                
                You can use RowDefinition and ColumnDefinition elements to define rows and columns 
                respectively. For each row or column, you can specify a minimum and maximum height 
                or width, or a fixed height or width. You can specify heights and widths in three 
                ways: 

                    • As numerical units. For example, Width="200" represents 200 units (where 1 
                    unit equals 1/96th of an inch). 
                    • As Auto. For example, Width="Auto" will set the column to the minimum width 
                    required to render all the child controls in the column. 
                    • As a star value. For example, Width="*" will make the column use up any 
                    available space after fixed-width columns and auto-width columns are allocated. 
                    If you create two columns with widths of 3* and 7*, the available space will be 
                    divided between the columns in the ratio 3:7.
                    
                To put a child control in a particular row or column, you add the Grid.Row and 
                Grid.Column attributes to the child control element. Note that these properties are 
                defined by the parent Grid element, rather than the child Label element. Properties 
                such as Grid.Row and Grid.Column are known as attached properties—they are defined 
                by a parent element to be specified by its child elements. Attached properties enable 
                child elements to tell a parent element how they should be rendered. 

                https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.grid?view=netframework-4.7.2

                */
                Console.WriteLine("** Using a Grid Layout");
                {
                    //<Grid>
                    //    <Grid.RowDefinitions>
                    //        <RowDefinition Height="100" MaxHeight="200" />
                    //        <RowDefinition Height="Auto" />
                    //    </Grid.RowDefinitions>
                    //    <Grid.ColumnDefinitions>
                    //        <ColumnDefinition Width="3*" />
                    //        <ColumnDefinition Width="7*" />
                    //    </Grid.ColumnDefinitions>
                    //    <Label Content="This is Row 0, Column 0" Grid.Row="0" Grid.Column="0" />
                    //    <Label Content="This is Row 0, Column 1" Grid.Row="0" Grid.Column="1" />
                    //    <Label Content="This is Row 1, Column 0" Grid.Row="1" Grid.Column="0" />
                    //    <Label Content="This is Row 1, Column 1" Grid.Row="1" Grid.Column="1" />
                    //</Grid>
                }

                Console.WriteLine("** Using a StackPanel Layout");
                {
                    // https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.stackpanel?view=netframework-4.7.2
                }

                Console.WriteLine("** Using a VirtualizingStackPanel Layout");
                {
                    // https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.virtualizingstackpanel?view=netframework-4.7.2
                }

                Console.WriteLine("** Using a WrapPanel Layout");
                {
                    // https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.wrappanel?view=netframework-4.7.2
                }
            }
        }

        /*
        
        When you work with WPF, you can create your own self-contained, reusable user controls 
        in XAML. User controls are sometimes called composite controls, because they are a 
        composite of other controls. For example, if you use the same combination of a text box 
        and a button multiple times in a UI, it might be more convenient to create and use a user 
        control that consists of the text box and the button. Alternatively, you might create a 
        user control to enable multiple developers to share the same custom control across 
        multiple assemblies. 

        Like a regular XAML window, user controls consist of a XAML file and a corresponding 
        code-behind file. In the XAML file, the principal difference is that the top-level element 
        is a UserControl element rather than a Window element.

        */
        public static void CreatingUserControls()
        {
            Console.WriteLine("* Creating User Controls");
            {
                /*
                
                Creating the XAML for a user control is very similar to creating the XAML for a 
                window. 

                */
                Console.WriteLine("** Creating a User Control in XAML");
                {
                    //<UserControl x:Class="clu.active.learning.app.CoffeeSelector"
                    //             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    //             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    //             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
                    //             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
                    //             xmlns:local="clr-namespace:clu.active.learning.app"
                    //             mc:Ignorable="d" 
                    //             d:DesignHeight="450" d:DesignWidth="800">
                    //    <Grid>
                    //        <Grid.RowDefinitions>
                    //            <RowDefinition Height="2*"/>
                    //            <RowDefinition Height="2*"/>
                    //            <RowDefinition Height="2*"/>
                    //            <RowDefinition Height="1*"/>
                    //        </Grid.RowDefinitions>
                    //        <StackPanel Grid.Row="0">
                    //            <Label Content="Do you want coffee or tea?"/>
                    //            <RadioButton x:Name="radCoffee" Content="Coffee" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="5" GroupName="Beverage" IsChecked="True" Checked="radCoffee_Checked" />
                    //            <RadioButton x:Name="radTea" Content="Tea" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="5" GroupName="Beverage" Checked="radTea_Checked"/>
                    //        </StackPanel>
                    //        <StackPanel Grid.Row="1">
                    //            <Label Content="Do you want milk?"/>
                    //            <RadioButton x:Name="radMilk" Content="Milk" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="5" GroupName="Milk" IsChecked="True" Checked="radMilk_Checked" />
                    //            <RadioButton x:Name="radNoMilk" Content="No Milk" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="5 " GroupName="Milk" Checked="radNoMilk_Checked"/>
                    //        </StackPanel>
                    //        <StackPanel Grid.Row="2">
                    //            <Label Content="Do you want sugar?"/>
                    //            <RadioButton x:Name="radSugar" Content="Sugar" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="5" GroupName="Sugar" IsChecked="True" Checked="radSugar_Checked" />
                    //            <RadioButton x:Name="radNoSugar" Content="No Sugar" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="5" GroupName="Sugar" Checked="radNoSugar_Checked"/>
                    //        </StackPanel>
                    //        <Button x:Name="btnOrder" Content="Place Order" Margin="5" Grid.Row="3" Click="btnOrder_Click"/>
                    //    </Grid>
                    //</UserControl>
                }

                /*
                
                In the code-behind file for the user control, you can create event handler 
                methods in the same way that you would for regular XAML windows. When you edit 
                the code-behind file, you should also: 

                    • Define any required public properties. Creating public properties enables 
                    the consumers of your user control to get or set property values, either in 
                    XAML or in code. 
                    • Define any required public events. Raising events enables consumers of your 
                    user control to respond in the same way that they would respond to other 
                    control events, such as the Click event of a button.

                */
                Console.WriteLine("** Creating the Code-Behind Class for a User Control");
                {
                    //public partial class CoffeeSelector : UserControl
                    //{
                    //    public CoffeeSelector()
                    //    {
                    //        InitializeComponent();
                    //    }

                    //    private string beverage;
                    //    private string milk;
                    //    private string sugar;

                    //    public string Order
                    //    {
                    //        get
                    //        {
                    //            return $"{beverage}, {milk}, {sugar}";
                    //        }
                    //    }
                    //    public event EventHandler<EventArgs> OrderPlaced;

                    //    private void btnOrder_Click(object sender, RoutedEventArgs e)
                    //    {
                    //        if (OrderPlaced != null)
                    //            OrderPlaced(this, EventArgs.Empty);
                    //    }

                    //    private void radCoffee_Checked(object sender, RoutedEventArgs e) { beverage = "Coffee"; }
                    //    private void radTea_Checked(object sender, RoutedEventArgs e) { beverage = "Tea"; }
                    //    private void radMilk_Checked(object sender, RoutedEventArgs e) { milk = "Milk"; }
                    //    private void radNoMilk_Checked(object sender, RoutedEventArgs e) { milk = "No Milk"; }
                    //    private void radSugar_Checked(object sender, RoutedEventArgs e) { sugar = "Sugar"; }
                    //    private void radNoSugar_Checked(object sender, RoutedEventArgs e) { sugar = "No Sugar"; }
                    //}
                }

                /*
                
                To use your user control in a WPF application, you need to do two things:

                1. Add a namespace prefix for your user control namespace and assembly to the Window 
                element. This should take the following form:
                
                    xmlns: [your prefix] ="clr-namespace: [your namespace] , [your assembly name] " 
                
                If your application and your user control are in the same assembly, you can omit the 
                assembly name from the namespace prefix declaration. 
                
                2. Add the control to your application in the same way that you would add a built-in 
                control, with the namespace prefix you defined. 

                */
                Console.WriteLine("** Adding a User Control to a WPF Application");
                {
                    //<Window x:Class="clu.active.learning.app.MainWindow"
                    //        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    //        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    //        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                    //        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"    
                    //        xmlns:coffee="clr-namespace:clu.active.learning.app"
                    //        mc:Ignorable="d"
                    //        Title="Order Your Coffee Here" Height="350" Width="525">
                    //    <Grid>
                    //        <Grid.RowDefinitions>
                    //            <RowDefinition Height="8*" />
                    //            <RowDefinition Height="*" />
                    //        </Grid.RowDefinitions>
                    //        <coffee:CoffeeSelector x:Name="coffeeSelector1" Grid.Row="0" OrderPlaced="coffeeSelector1_OrderPlaced"  />
                    //        <Label x:Name="lblResult" Margin="5" Grid.Row="1" />
                    //    </Grid>
                    //</Window>
                }
            }
        }

        #endregion
    }
}
