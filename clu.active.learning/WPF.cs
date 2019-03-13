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

                    1. Add a namespace prefix for your user control namespace and assembly to the 
                    Window element. This should take the following form:
                
                        xmlns: [your prefix] ="clr-namespace: [your namespace] , [your assembly name] " 
                
                    If your application and your user control are in the same assembly, you can omit 
                    the assembly name from the namespace prefix declaration. 
                
                    2. Add the control to your application in the same way that you would add a 
                    built-in control, with the namespace prefix you defined. 

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

        /*
        
        Data binding is the act of connecting a data source to a UI element in such a way that if one 
        changes, the other must also change. Conceptually, data binding consists of three components: 

            • The binding source. This is the source of your data, and is typically a property of a 
            custom .NET object. For example, you might bind a control to the CountryOfOrigin property 
            of a Coffee object. 
            • The binding target. This is the XAML element you want to bind to your data source, and 
            is typically a UI control. You must bind your data source to a property of your target 
            object, and that property must be a dependency property. For example, you might bind data 
            to the Content property of a TextBox element. 
            • The binding object. This is the object that connects the source to the target. The 
            Binding object can also specify a converter, if the source property and the target property 
            are of different data types. 

        A dependency property is a special type of wrapper around a regular property. Dependency 
        properties are registered with the .NET Framework runtime, which enables the runtime to notify 
        any interested parties when the value of the underlying property changes. This ability to 
        notify changes is what makes data binding work. Most built-in UI elements implement dependency 
        properties and will support data binding. 
        
        http://go.microsoft.com/fwlink/?LinkID=267829
            
        */
        public static void UsingDataBinding()
        {
            Console.WriteLine("* Using Data Binding");
            {
                /*
                
                In this example, the Text property of a TextBlock is set to a data binding expression. 
                Note that: 
                    
                    • The Binding expression is enclosed in braces. This enables you to set properties 
                    on the Binding object before it is evaluated by the TextBlock. 
                    • The Source property of the Binding object is set to {StaticResource coffee1}. This 
                    is an object instance defined elsewhere in the solution. 
                    • The Path property of the Binding object is set to Bean. This indicates that you want 
                    to bind to the Bean property of the coffee1 object. 

                As a result of this expression, the TextBlock will always display the value of the Bean 
                property of the coffee1 object. If the value of the Bean property changes, the TextBlock 
                will update automatically. In terms of the concepts described at the start of this topic: 

                    • The binding source is the Bean property of the coffee1 object. 
                    • The binding target is the Text property of the TextBlock element. 
                    • The binding object is defined by the expression in braces. 

                */
                Console.WriteLine("** Simple Data Binding");
                {
                    //<TextBlock Text="{Binding Source={StaticResource coffee1}, Path=Bean}" />
                }

                /*
                
                You can also configure the direction of the data binding. For example, you might want to 
                update the UI when the source data is changed or you might want to update the source data 
                when the user edits a value in the UI. To specify the direction of the binding, you set the 
                Mode property of the Binding object. The Mode property can take the following values:

                Mode Value          Details
                TwoWay              Updates the target property when the source property changes, and 
                                    updates the source property when the target property changes. 
                OneWay              Updates the target property when the source property changes.
                OneTime             Updates the target property only when the application starts or when 
                                    the DataContext property of the target is changed. 
                OneWayToSource      Updates the source property when the target property changes.
                Default             Uses the default Mode value of the target property.

                https://docs.microsoft.com/en-us/dotnet/framework/wpf/data/data-binding-overview

                */
                Console.WriteLine("** Specify the Binding Direction");
                {
                    //<TextBox Text="{Binding Source={StaticResource coffee1}, Path=Bean, Mode=TwoWay}" />
                }

                /*
                
                You can bind controls to data in various ways. If your source data will not change during 
                the execution of your application, you can create a static resource to represent your data 
                in XAML. A static resource enables you to create instances of classes. For example, if your 
                assembly contains a class named Coffee, you can define a static resource to create an 
                instance of Coffee and set properties on it. To create a static resource, you must: 

                    • Add an element to the Resources property of a container control, such as the top-level 
                    Window. 
                    • Set the name of the element to the name of the class you want to instantiate. For 
                    example, if you want to create an instance of the Coffee class, create an element named 
                    Coffee. Use a namespace prefix declaration to identify the namespace and assembly that 
                    contains your class. 
                    • Add an x:Key attribute to the element. This is the identifier by which you will specify 
                    the static resource in data binding expressions. You can create multiple instances of a 
                    resource in a window, but each instance should have a unique x:Key value. 

                */
                Console.WriteLine("** Creating a Static Resource");
                {
                    //<Window x:Class="DataBinding.MainWindow"
                    //                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    //                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    //                xmlns:loc="clr-namespace:DataBinding"
                    //                Title="Data Binding Example" Height="350" Width="525">
                    //   <Window.Resources>
                    //      <loc:Coffee x:Key="coffee1" Name="Fourth Coffee Quencher" Bean="Arabica" CountryOfOrigin="Brazil" Strength="3" />
                    //      …
                    //   </Window.Resources>
                    //   …
                    //</Window>
                }

                /*
                
                If you want to bind an individual UI element to this static resource, you can use a binding 
                statement that specifies both a source and a path. You set the Source property to the static 
                resource, and set the Path property to the specific property in the source object to which 
                you want to bind. 

                */
                Console.WriteLine("** Binding an Individual Item to a Static Resource ");
                {
                    //<TextBlock Text="{Binding Source={StaticResource coffee1}, Path=Name}" />
                }

                /*
                 
                More commonly, you will want to bind multiple UI elements to different properties of a data 
                source. In this case, you can set the DataContext property on a container object, such as a 
                Grid or a StackPanel. Setting a DataContext property is similar to providing a partial data 
                binding expression. It specifies the source object, but does not identify specific properties. 
                Any child controls within the container object will inherit this data context, unless you 
                override it. This means that when you create data binding expressions for child controls, you 
                can omit the source and simply specify the path to the property of interest. 

                */
                Console.WriteLine("** Specifying a Data Context");
                {
                    //<StackPanel>
                    //   <StackPanel.DataContext>
                    //      <Binding Source="{StaticResource coffee1}" />
                    //   </StackPanel.DataContext>
                    //   <TextBlock Text="{Binding Path=Name}" />
                    //   <TextBlock Text="{Binding Path=}" />
                    //   <TextBlock Text="{Binding Path=CountryOfOrigin}" />
                    //   <TextBlock Text="{Binding Path=Strength}" />
                    //</StackPanel>
                }

                /*
                In real-world applications, it is unlikely that your source data will be static. It is far 
                more likely that you will retrieve data at runtime from a database or a web service. In these 
                scenarios, you cannot use a static resource to represent your data. Instead, you must use code 
                to specify the data source for any UI bindings at runtime. 

                In many cases you can use a mixture of XAML binding and code binding. For example, you might 
                know that your UI elements will be bound to a Coffee instance at design time. In this case, 
                you can specify the binding paths in XAML, and then set a DataContext property in code. 

                In this example, you have set the binding path for each individual text block in XAML. To 
                complete the binding, all you need to do is to set the DataContext property of the parent 
                StackPanel object to the Coffee instance that you want to display.

                */
                Console.WriteLine("** Specifying Binding Paths in XAML");
                {
                    //<StackPanel x:Name="stackCoffee">
                    //   <TextBlock Text="{Binding Path=Name}" />
                    //   <TextBlock Text="{Binding Path=}" />
                    //   <TextBlock Text="{Binding Path=CountryOfOrigin}" />
                    //   <TextBlock Text="{Binding Path=Strength}" />
                    //</StackPanel>
                }

                /*
                 * 
                In many scenarios, you will want to data bind a control to a collection of objects. WPF 
                includes controls that are designed to render collections, such as the ListBox control, the 
                ListView control, the ComboBox control, and the TreeView control. These controls all inherit 
                from the ItemsControl class and, as such, support a common approach to data binding. 

                To bind a collection to an ItemsControl instance, you need to: 

                    • Specify the source data collection in the ItemsSource property of the ItemsControl 
                    instance. 
                    • Specify the source property you want to display in the DisplayMemberPath property of the 
                    ItemsControl instance. 

                You can bind an ItemsControl instance to any collection that implements the IEnumerable 
                interface. You can set the ItemsSource and DisplayMemberPath properties in XAML or in code. 
                One common approach is to define the DisplayMemberPath property (or a data template) in XAML, 
                and then to set the ItemsSource programmatically at runtime. 

                */
                Console.WriteLine("** Setting the DisplayMemberPath Property");
                {
                    //<ListBox x:Name="lstCoffees" DisplayMemberPath="Name" />
                }

                /*

                Having set the DisplayMemberPath property in XAML, you can now set the ItemsSource property 
                in code to complete the data binding. 

                If you want a control displaying data in a collection to be updated automatically when items 
                are added or removed, the collection must implement the INotifyPropertyChanged interface. This 
                interface defines an event called PropertyChanged that the collection can raise after making a 
                change. The .NET Framework includes a class named ObservableCollection<T> that provides a 
                generic implementation of INotifyPropertyChanged. 

                The control that binds to the collection receives the event, and can use it to refresh the data 
                that it is displaying. Many of the WPF container controls catch and handle this event 
                automatically. 

                https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=netframework-4.7.2

                https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.7.2

                */
                Console.WriteLine("** Setting the ItemsSource Property");
                {
                    //// Create some Coffee instances.
                    //var coffee1 = new Coffee("Fourth Coffee Quencher");
                    //var coffee2 = new Coffee("Espresso Number Four");
                    //var coffee3 = new Coffee("Fourth Refresher");
                    //var coffee3 = new Coffee("Fourth Frenetic");
                    //// Add the items to an observable collection.
                    //var coffees = new ObservableCollection<Coffee>();
                    //coffees.Add(coffee1);
                    //coffees.Add(coffee2);
                    //coffees.Add(coffee3);
                    //coffees.Add(coffee4);
                    //// Set the ItemsSource property of the ListBox to the coffees collection.
                    //lstCoffees.ItemsSource = coffees;
                }

                /*
                
                When you use controls that derive from the ItemsControl or ContentControl control, you can create
                a data template to specify how your items are rendered. For example, suppose you want to use a
                ListBox control to display a collection of Coffee instances. Each Coffee instance includes several 
                properties to represent the name of the coffee, the type of coffee bean, the country of origin, 
                and the strength of the coffee. The data template specifies how each Coffee instance should be 
                rendered, by mapping properties of the Coffee instance to child controls within the data template. 
                Creating a data template gives you precise control over how your items are rendered and styled. 

                https://docs.microsoft.com/en-us/dotnet/framework/wpf/data/data-templating-overview

                */
                Console.WriteLine("** Creating a Data Template");
                {
                    //<ListBox x:Name="lstCoffees" Width="200">
                    //   <ListBox.ItemTemplate>
                    //      <DataTemplate>
                    //         <Grid>
                    //            <Grid.RowDefinitions>
                    //               <RowDefinition Height="2*" />
                    //               <RowDefinition Height="*" />
                    //               <RowDefinition Height="*" />
                    //               <RowDefinition Height="*" />
                    //            </Grid.RowDefinitions>
                    //            <TextBlock Text="{Binding Path=Name}" Grid.Row="0"
                    //                    FontSize="22" Background="Black" Foreground="" />
                    //            <TextBlock Text="{Binding Path=}" Grid.Row="1" />
                    //            <TextBlock Text="{Binding Path=CountryOfOrigin}" Grid.Row="2" />
                    //            <TextBlock Text="{Binding Path=Strength}" Grid.Row="3" />
                    //         </Grid>
                    //      </DataTemplate>
                    //   </ListBox.ItemTemplate>
                    //</ListBox>
                }
            }
        }

        /*
         
        XAML enables you to create certain elements, such as data templates, styles, and brushes, as 
        reusable resources. This has various advantages when you are developing a graphical application: 

            • You can define a resource once and use it in multiple places.
            • You can edit a resource without editing every element that uses the resource.
            • Your XAML files are shorter and easier to read.

        Every WPF control has a Resources property to which you can add resources. This is because the 
        Resources property is defined by the FrameworkElement class from which all WPF elements ultimately 
        derive. In most cases, you define resources on the root element in a file, such as the Window 
        element or the UserControl element. The resources are then available to the root element and all of 
        its descendants. You can also create resources for use across the entire application by defining 
        them in the App.xaml file. 

        Every WPF application has an App.xaml file. It is a XAML file that can contain global resources 
        used by all windows and controls in a WPF application. It is also the entry point for the 
        application, and defines which window should appear when an application starts. 

        https://docs.microsoft.com/en-us/dotnet/framework/wpf/controls/styling-and-templating

        */
        public static void UsingStyling()
        {
            Console.WriteLine("* Using Styling");
            {
                /*
         
                Resources are stored in a dictionary collection of type ResourceDictionary. When you create 
                a reusable resource, you must give it a unique key by providing a value for the x:Key 
                attribute. 
        
                */
                Console.WriteLine("** Creating and Using Resources");
                {
                    //<Window x:Class="DataBinding.MainWindow"
                    //                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    //                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    //                Title="Reusable Resources" Height="350" Width="525">
                    //   <Window.Resources>
                    //       <SolidColorBrush x:Key="MyBrush" Color="Coral" />
                    //      …
                    //   </Window.Resources>
                    //   …
                    //</Window>
                }

                /*
                
                To reference a resource, you use the format {StaticResource [resource key]}. You can use the 
                resource in any property that accepts values of the same type as the resource, provided that 
                the resource is in scope. For example, if you create a brush as a resource, you can reference 
                the brush in any property that accepts brush types, such as Foreground, Background, or Fill. 

                */
                Console.WriteLine("** Referencing a Reusable Resource");
                {
                    //<StackPanel>
                    //   <Button Content="Click Me" Background="{MyBrush}" />
                    //   <TextBlock Text="Foreground" Foreground="{MyBrush}" />
                    //   <TextBlock Text="Background" Background="{MyBrush}" />
                    //   <Ellipse Height="50" Fill="{MyBrush}" />
                    //</StackPanel>
                }

                /*
               
                If you need to create several reusable resources, it can be useful to create your resources 
                in a separate resource dictionary file. A resource dictionary is a XAML file with a top-level 
                element of ResourceDictionary. You can add reusable resources within the ResourceDictionary 
                element in the same way that you would add them to a Window.Resources element. 

                In most cases, you make a resource dictionary available for use in your application by 
                referencing it in the application-scoped App.xaml file.

                */
                Console.WriteLine("** Referencing a Resource Dictionary");
                {
                    //<Application x:Class="ReusableResources.App"
                    //                     xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    //                     xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    //                     StartupUri="MainWindow.xaml">
                    //    <Application.Resources>
                    //        <ResourceDictionary>
                    //            <ResourceDictionary.MergedDictionaries>
                    //                <ResourceDictionary Source="FourthCoffeeResources.xaml" />
                    //            </ResourceDictionary.MergedDictionaries>
                    //        </ResourceDictionary>
                    //    </Application.Resources>
                    //</Application>
                }

                /*
                
                In many cases, you will want to apply the same property values to multiple controls of the 
                same type within an application. For example, if a page contains five textboxes, you will 
                probably want each textbox to have the same foreground color, background color, font size, 
                and so on. To make this consistency easier to manage, you can create Style elements as 
                resources in XAML. Style elements enable you to apply a collection of property values to 
                some or all controls of a particular type. To create a style, perform the following steps: 

                    1. Add a Style element to a resource collection within your application (for example, 
                    the Window.Resources collection or a resource dictionary). 
                    2. Use the TargetType attribute of the Style element to specify the type of control you 
                    want the style to target (for example, TextBox or Button). 
                    3. Use the x:Key attribute of the Style element to enable controls to specify this style. 
                    Alternatively, you can omit the x:Key attribute and your style will apply to all controls 
                    of the specified type. 
                    4. Within the Style element, use Setter elements to apply specific values to specific 
                    properties. 

                */
                Console.WriteLine("** Creating Styles");
                {
                    //<Window.Resources>
                    //    <Style TargetType="TextBlock" x:Key="BlockStyle1">
                    //        <Setter Property="FontSize" Value="20" />
                    //        <Setter Property="Background" Value="" />
                    //        <Setter Property="Foreground">
                    //            <Setter.Value>
                    //                <="0.5,0" EndPoint="0.5,1">
                    //                    <LinearGradientBrush.GradientStops>
                    //                        <GradientStop Offset="0.0" Color="Orange" />
                    //                        <GradientStop Offset="1.0" Color="Red" />
                    //                    </LinearGradientBrush.GradientStops>
                    //                </LinearGradientBrush>
                    //            </Setter.Value>
                    //        </Setter>
                    //    </Style>
                    //    …
                    //</Window.Resources>
                }

                /*
                
                To apply this style to a TextBlock control, you need to set the Style attribute of the 
                TextBlock to the x:Key value of the style resource. 
                
                */
                Console.WriteLine("** Applying Styles");
                {
                    //<TextBlock Text="Drink More Coffee" Style="{StaticResource BlockStyle1}" />
                }
            }
        }

        /*
        
        When you create a style in XAML, you can specify property values that are only applied when 
        certain conditions are true. For example, you might want to change the font style of a button when 
        the user hovers over it, or you might want to apply a highlighting effect to selected items in a 
        list box. 

        To apply style properties based on conditions, you add Trigger elements to your styles. The Trigger 
        element identifies the property of interest and the value that should trigger the change. Within the 
        Trigger element, you use Setter elements to apply changes to property values. 

        */
        public static void UsingPropertyTriggers()
        {
            Console.WriteLine("* Using Property Triggers");
            {
                Console.WriteLine("** Using a Property Trigger");
                {
                    //<Window.Resources>
                    //    <Style TargetType="Button">
                    //        <Style.Triggers>
                    //            <Trigger Property="IsMouseOver" Value="True">
                    //                <Setter Property="FontWeight" Value="Bold" />
                    //            </Trigger>
                    //        </Style.Triggers>
                    //    </Style>
                    //    …
                    //</Window.Resources>
                }
            }
        }

        /*
        
        Sophisticated graphical applications often use animations to make the user experience more engaging. 
        Animations are sometimes used to make transitions between states less abrupt. For example, if you 
        want to enlarge or rotate a picture, increasing the size or changing the orientation progressively 
        over a short time period can look better than simply switching from one size or orientation to 
        another. 

        To create and apply an animation effect in XAML, you need to do three things:

            1. Create an animation. WPF includes various classes that you can use to create animations in
            XAML. The most commonly used animation element is DoubleAnimation. The DoubleAnimation element 
            specifies how a value should change over time, by specifying the initial value, the final value, 
            and the duration over which the value should change. 
            2. Create a storyboard. To apply an animation to an object, you need to wrap your animation in a 
            Storyboard element. The Storyboard element enables you to specify the object and the property you 
            want to animate. It does this by providing the TargetName and TargetProperty attached properties, 
            which you can set on child animation elements. 
            3. Create a trigger. To trigger your animation in response to a property change, you need to wrap 
            your storyboard in an EventTrigger element. The EventTrigger element specifies the control event 
            that will trigger the animation. In the EventTrigger element, you can use a BeginStoryboard element 
            to launch the animation. 

        You can add an EventTrigger element containing your storyboards and animations to the Triggers 
        collection of a Style element, or you can add it directly to the Triggers collection of an 
        individual control.

        https://docs.microsoft.com/en-us/dotnet/framework/wpf/graphics-multimedia/animation-overview

        */
        public static void CreatingDynamicTransformations()
        {
            Console.WriteLine("* Creating Dynamic Transformations");
            {
                Console.WriteLine("** Creating an Animation Effect");
                {
                    //<Window.Resources>
                    //    <Style TargetType="Image" x:Key="CoffeeImageStyle">
                    //        <Setter Property="Height" Value="200" />
                    //        <Setter Property="RenderTransformOrigin" Value="0.5,0.5" />
                    //        <Setter Property="RenderTransform">
                    //            <Setter.Value>
                    //                <RotateTransform Angle="0" />
                    //            </Setter.Value>
                    //        </Setter>
                    //        <Style.Triggers>
                    //            <="Image.MouseDown">
                    //                <BeginStoryboard>
                    //                    <Storyboard>
                    //                         <DoubleAnimation Storyboard.TargetProperty="Height"
                    //                             From="200" To="300" Duration="0:0:2" />
                    //                         <DoubleAnimation Storyboard.TargetProperty="RenderTransform.Angle"
                    //                             From="0" To="30" Duration="0:0:2" />
                    //                    </Storyboard>
                    //                </BeginStoryboard>
                    //            </EventTrigger>
                    //        </Style.Triggers>
                    //    </Style>
                    //</Window.Resources>
                }
            }
        }

        #endregion
    }
}
