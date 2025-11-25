using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_Episode14_TabControl
{
    public partial class MainWindow : Window
    {
        private int wizardStep = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowBasicTabControl(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 1: Basic TabControl");

            AddDescription(mainStack, "TabControl provides tabbed navigation between pages:");

            var tabControl = new System.Windows.Controls.TabControl
            {
                Height = 300,
                Margin = new Thickness(0, 10, 0, 0)
            };

            // Home Tab
            var homeTab = new TabItem { Header = "Home" };
            var homeStack = new StackPanel
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            homeStack.Children.Add(new TextBlock { Text = "Welcome to Home Page!", FontSize = 20, FontWeight = FontWeights.Bold });
            homeStack.Children.Add(new TextBlock { Text = "This is the first tab", Margin = new Thickness(0, 10, 0, 0) });
            homeTab.Content = homeStack;
            tabControl.Items.Add(homeTab);

            // Profile Tab
            var profileTab = new TabItem { Header = "Profile" };
            var profileStack = new StackPanel
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            profileStack.Children.Add(new TextBlock { Text = "User Profile", FontSize = 20, FontWeight = FontWeights.Bold });
            profileStack.Children.Add(new TextBlock { Text = "View and edit your profile", Margin = new Thickness(0, 10, 0, 0) });
            profileTab.Content = profileStack;
            tabControl.Items.Add(profileTab);

            // Settings Tab
            var settingsTab = new TabItem { Header = "Settings" };
            var settingsStack = new StackPanel
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            settingsStack.Children.Add(new TextBlock { Text = "Application Settings", FontSize = 20, FontWeight = FontWeights.Bold });
            settingsStack.Children.Add(new TextBlock { Text = "Configure preferences", Margin = new Thickness(0, 10, 0, 0) });
            settingsTab.Content = settingsStack;
            tabControl.Items.Add(settingsTab);

            mainStack.Children.Add(tabControl);
            UpdateContent(mainStack);
        }

        private void ShowCustomHeaders(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 2: Custom Tab Headers");

            AddDescription(mainStack, "Tab headers can be customized with icons, badges, and rich content:");

            var tabControl = new System.Windows.Controls.TabControl
            {
                Height = 350,
                Margin = new Thickness(0, 10, 0, 0)
            };

            // Tab with icon
            var homeTab = new TabItem();
            var homeHeader = new StackPanel { Orientation = Orientation.Horizontal };
            homeHeader.Children.Add(new TextBlock { Text = "🏠", FontSize = 16, Margin = new Thickness(0, 0, 5, 0) });
            homeHeader.Children.Add(new TextBlock { Text = "Home" });
            homeTab.Header = homeHeader;
            homeTab.Content = new TextBlock { Text = "Home content with icon in header", Margin = new Thickness(20), VerticalAlignment = VerticalAlignment.Center };
            tabControl.Items.Add(homeTab);

            // Tab with badge (notification count)
            var messageTab = new TabItem();
            var messageHeader = new StackPanel { Orientation = Orientation.Horizontal };
            messageHeader.Children.Add(new TextBlock { Text = "📧", FontSize = 16, Margin = new Thickness(0, 0, 5, 0) });
            messageHeader.Children.Add(new TextBlock { Text = "Messages", Margin = new Thickness(0, 0, 5, 0) });
            var badge = new Border
            {
                Background = Brushes.Red,
                CornerRadius = new CornerRadius(10),
                Padding = new Thickness(5, 2)
            };
            badge.Child = new TextBlock { Text = "12", Foreground = Brushes.White, FontSize = 11, FontWeight = FontWeights.Bold };
            messageHeader.Children.Add(badge);
            messageTab.Header = messageHeader;
            messageTab.Content = new TextBlock { Text = "You have 12 new messages!", Margin = new Thickness(20), VerticalAlignment = VerticalAlignment.Center };
            tabControl.Items.Add(messageTab);

            // Tab with styled header
            var premiumTab = new TabItem();
            var premiumBorder = new Border
            {
                Background = (Brush)new BrushConverter().ConvertFrom("#FFD700"),
                CornerRadius = new CornerRadius(3),
                Padding = new Thickness(8, 4)
            };
            premiumBorder.Child = new TextBlock { Text = "⭐ Premium", FontWeight = FontWeights.Bold };
            premiumTab.Header = premiumBorder;
            premiumTab.Content = new TextBlock { Text = "Premium features", Margin = new Thickness(20), VerticalAlignment = VerticalAlignment.Center };
            tabControl.Items.Add(premiumTab);

            // Tab with multi-line header
            var analyticsTab = new TabItem();
            var analyticsHeader = new StackPanel();
            analyticsHeader.Children.Add(new TextBlock { Text = "Analytics", FontWeight = FontWeights.Bold });
            analyticsHeader.Children.Add(new TextBlock { Text = "View stats", FontSize = 9, Foreground = Brushes.Gray });
            analyticsTab.Header = analyticsHeader;
            analyticsTab.Content = new TextBlock { Text = "Analytics dashboard", Margin = new Thickness(20), VerticalAlignment = VerticalAlignment.Center };
            tabControl.Items.Add(analyticsTab);

            mainStack.Children.Add(tabControl);
            UpdateContent(mainStack);
        }

        private void ShowTabPositions(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 3: Tab Strip Positioning");

            AddDescription(mainStack, "Tabs can be positioned at Top, Bottom, Left, or Right:");

            var grid = new UniformGrid { Rows = 2, Columns = 2, Margin = new Thickness(0, 10, 0, 0) };

            // Top
            var topTab = CreateSimpleTabControl(Dock.Top);
            topTab.Margin = new Thickness(5);
            grid.Children.Add(topTab);

            // Bottom
            var bottomTab = CreateSimpleTabControl(Dock.Bottom);
            bottomTab.Margin = new Thickness(5);
            grid.Children.Add(bottomTab);

            // Left
            var leftTab = CreateSimpleTabControl(Dock.Left);
            leftTab.Margin = new Thickness(5);
            grid.Children.Add(leftTab);

            // Right
            var rightTab = CreateSimpleTabControl(Dock.Right);
            rightTab.Margin = new Thickness(5);
            grid.Children.Add(rightTab);

            mainStack.Children.Add(grid);
            UpdateContent(mainStack);
        }

        private void ShowSettingsPanel(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 4: Application Settings");

            AddDescription(mainStack, "Professional settings panel with categorized options:");

            var tabControl = new System.Windows.Controls.TabControl
            {
                Height = 400,
                Margin = new Thickness(0, 10, 0, 0)
            };

            // General Settings
            var generalTab = new TabItem { Header = "⚙️ General" };
            var generalScroll = new ScrollViewer();
            var generalStack = new StackPanel { Margin = new Thickness(20) };
            generalStack.Children.Add(new TextBlock { Text = "General Settings", FontSize = 18, FontWeight = FontWeights.Bold, Margin = new Thickness(0, 0, 0, 15) });
            var startupGroup = new GroupBox { Header = "Startup", Padding = new Thickness(10), Margin = new Thickness(0, 5) };
            var startupStack = new StackPanel();
            startupStack.Children.Add(new CheckBox { Content = "Start with Windows", Margin = new Thickness(0, 5) });
            startupStack.Children.Add(new CheckBox { Content = "Minimize to tray", Margin = new Thickness(0, 5), IsChecked = true });
            startupStack.Children.Add(new CheckBox { Content = "Check for updates", Margin = new Thickness(0, 5), IsChecked = true });
            startupGroup.Content = startupStack;
            generalStack.Children.Add(startupGroup);
            generalScroll.Content = generalStack;
            generalTab.Content = generalScroll;
            tabControl.Items.Add(generalTab);

            // Appearance Settings
            var appearanceTab = new TabItem { Header = "🎨 Appearance" };
            var appearanceScroll = new ScrollViewer();
            var appearanceStack = new StackPanel { Margin = new Thickness(20) };
            appearanceStack.Children.Add(new TextBlock { Text = "Appearance Settings", FontSize = 18, FontWeight = FontWeights.Bold, Margin = new Thickness(0, 0, 0, 15) });
            var themeGroup = new GroupBox { Header = "Theme", Padding = new Thickness(10), Margin = new Thickness(0, 5) };
            var themeStack = new StackPanel();
            themeStack.Children.Add(new RadioButton { Content = "Light", GroupName = "Theme", IsChecked = true, Margin = new Thickness(0, 5) });
            themeStack.Children.Add(new RadioButton { Content = "Dark", GroupName = "Theme", Margin = new Thickness(0, 5) });
            themeStack.Children.Add(new RadioButton { Content = "Auto (system)", GroupName = "Theme", Margin = new Thickness(0, 5) });
            themeGroup.Content = themeStack;
            appearanceStack.Children.Add(themeGroup);
            appearanceScroll.Content = appearanceStack;
            appearanceTab.Content = appearanceScroll;
            tabControl.Items.Add(appearanceTab);

            // Privacy Settings
            var privacyTab = new TabItem { Header = "🔒 Privacy" };
            var privacyScroll = new ScrollViewer();
            var privacyStack = new StackPanel { Margin = new Thickness(20) };
            privacyStack.Children.Add(new TextBlock { Text = "Privacy Settings", FontSize = 18, FontWeight = FontWeights.Bold, Margin = new Thickness(0, 0, 0, 15) });
            var dataGroup = new GroupBox { Header = "Data Collection", Padding = new Thickness(10), Margin = new Thickness(0, 5) };
            var dataStack = new StackPanel();
            dataStack.Children.Add(new CheckBox { Content = "Anonymous usage statistics", Margin = new Thickness(0, 5) });
            dataStack.Children.Add(new CheckBox { Content = "Crash reports", Margin = new Thickness(0, 5), IsChecked = true });
            dataStack.Children.Add(new CheckBox { Content = "Personalized ads", Margin = new Thickness(0, 5) });
            dataGroup.Content = dataStack;
            privacyStack.Children.Add(dataGroup);
            privacyScroll.Content = privacyStack;
            privacyTab.Content = privacyScroll;
            tabControl.Items.Add(privacyTab);

            mainStack.Children.Add(tabControl);
            UpdateContent(mainStack);
        }

        private void ShowDocumentEditor(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 5: Document Editor");

            AddDescription(mainStack, "Multi-document interface like Notepad++ or VS Code:");

            var dockPanel = new DockPanel { Margin = new Thickness(0, 10, 0, 0) };

            // Toolbar
            var toolbar = new ToolBar();
            DockPanel.SetDock(toolbar, Dock.Top);
            toolbar.Items.Add(new Button { Content = "New", Padding = new Thickness(10, 5) });
            toolbar.Items.Add(new Button { Content = "Open", Padding = new Thickness(10, 5) });
            toolbar.Items.Add(new Button { Content = "Save", Padding = new Thickness(10, 5) });
            toolbar.Items.Add(new Separator());
            toolbar.Items.Add(new Button { Content = "Cut", Padding = new Thickness(10, 5) });
            toolbar.Items.Add(new Button { Content = "Copy", Padding = new Thickness(10, 5) });
            toolbar.Items.Add(new Button { Content = "Paste", Padding = new Thickness(10, 5) });
            dockPanel.Children.Add(toolbar);

            // Document Tabs
            var tabControl = new System.Windows.Controls.TabControl { Height = 300 };

            // Document 1
            var doc1Tab = new TabItem();
            var doc1Header = new StackPanel { Orientation = Orientation.Horizontal };
            doc1Header.Children.Add(new TextBlock { Text = "Document1.txt", Margin = new Thickness(0, 0, 10, 0) });
            doc1Header.Children.Add(new TextBlock { Text = "●", Foreground = Brushes.Red, ToolTip = "Modified" });
            doc1Tab.Header = doc1Header;
            doc1Tab.Content = new TextBox
            {
                AcceptsReturn = true,
                TextWrapping = TextWrapping.Wrap,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Padding = new Thickness(10),
                Text = "This is the content of Document 1.\n\nIt has been modified (red dot).\n\nYou can edit this text..."
            };
            tabControl.Items.Add(doc1Tab);

            // Document 2
            var doc2Tab = new TabItem();
            doc2Tab.Header = "README.md";
            doc2Tab.Content = new TextBox
            {
                AcceptsReturn = true,
                TextWrapping = TextWrapping.Wrap,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Padding = new Thickness(10),
                FontFamily = new FontFamily("Consolas"),
                Text = "# My Project\n\nThis is a sample README file.\n\n## Features\n- Feature 1\n- Feature 2\n- Feature 3"
            };
            tabControl.Items.Add(doc2Tab);

            // Document 3
            var doc3Tab = new TabItem { Header = "Notes.txt" };
            doc3Tab.Content = new TextBox
            {
                AcceptsReturn = true,
                TextWrapping = TextWrapping.Wrap,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Padding = new Thickness(10),
                Text = "Meeting notes:\n\n1. Review project status\n2. Discuss timeline\n3. Assign tasks"
            };
            tabControl.Items.Add(doc3Tab);

            dockPanel.Children.Add(tabControl);
            mainStack.Children.Add(dockPanel);
            UpdateContent(mainStack);
        }

        private void ShowWizardForm(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 6: Wizard Form");

            AddDescription(mainStack, "Multi-step registration form:");

            var tabControl = new System.Windows.Controls.TabControl
            {
                Height = 400,
                Margin = new Thickness(0, 10, 0, 0),
                Name = "WizardTabControl"
            };

            // Step 1: Personal Info
            var step1Tab = new TabItem { Header = "1️⃣ Personal Info" };
            var step1Stack = new StackPanel { Margin = new Thickness(20) };
            step1Stack.Children.Add(new TextBlock { Text = "Personal Information", FontSize = 18, FontWeight = FontWeights.Bold, Margin = new Thickness(0, 0, 0, 15) });
            step1Stack.Children.Add(new TextBlock { Text = "First Name:" });
            step1Stack.Children.Add(new TextBox { Padding = new Thickness(5), Margin = new Thickness(0, 5, 0, 10) });
            step1Stack.Children.Add(new TextBlock { Text = "Last Name:" });
            step1Stack.Children.Add(new TextBox { Padding = new Thickness(5), Margin = new Thickness(0, 5, 0, 10) });
            step1Stack.Children.Add(new TextBlock { Text = "Email:" });
            step1Stack.Children.Add(new TextBox { Padding = new Thickness(5), Margin = new Thickness(0, 5, 0, 10) });
            var nextBtn1 = new Button { Content = "Next →", Padding = new Thickness(15, 8), HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, 20, 0, 0) };
            nextBtn1.Click += (s, ev) => { tabControl.SelectedIndex = 1; };
            step1Stack.Children.Add(nextBtn1);
            step1Tab.Content = step1Stack;
            tabControl.Items.Add(step1Tab);

            // Step 2: Address
            var step2Tab = new TabItem { Header = "2️⃣ Address" };
            var step2Stack = new StackPanel { Margin = new Thickness(20) };
            step2Stack.Children.Add(new TextBlock { Text = "Address Information", FontSize = 18, FontWeight = FontWeights.Bold, Margin = new Thickness(0, 0, 0, 15) });
            step2Stack.Children.Add(new TextBlock { Text = "Street:" });
            step2Stack.Children.Add(new TextBox { Padding = new Thickness(5), Margin = new Thickness(0, 5, 0, 10) });
            step2Stack.Children.Add(new TextBlock { Text = "City:" });
            step2Stack.Children.Add(new TextBox { Padding = new Thickness(5), Margin = new Thickness(0, 5, 0, 10) });
            step2Stack.Children.Add(new TextBlock { Text = "Zip Code:" });
            step2Stack.Children.Add(new TextBox { Padding = new Thickness(5), Margin = new Thickness(0, 5, 0, 10) });
            var btnPanel2 = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, 20, 0, 0) };
            var backBtn2 = new Button { Content = "← Back", Padding = new Thickness(15, 8), Margin = new Thickness(0, 0, 10, 0) };
            backBtn2.Click += (s, ev) => { tabControl.SelectedIndex = 0; };
            var nextBtn2 = new Button { Content = "Next →", Padding = new Thickness(15, 8) };
            nextBtn2.Click += (s, ev) => { tabControl.SelectedIndex = 2; };
            btnPanel2.Children.Add(backBtn2);
            btnPanel2.Children.Add(nextBtn2);
            step2Stack.Children.Add(btnPanel2);
            step2Tab.Content = step2Stack;
            tabControl.Items.Add(step2Tab);

            // Step 3: Confirmation
            var step3Tab = new TabItem { Header = "3️⃣ Confirm" };
            var step3Stack = new StackPanel { Margin = new Thickness(20) };
            step3Stack.Children.Add(new TextBlock { Text = "Review & Confirm", FontSize = 18, FontWeight = FontWeights.Bold, Margin = new Thickness(0, 0, 0, 15) });
            var reviewBorder = new Border
            {
                BorderBrush = Brushes.Gray,
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(5),
                Padding = new Thickness(15),
                Background = Brushes.LightGray
            };
            var reviewStack = new StackPanel();
            reviewStack.Children.Add(new TextBlock { Text = "Personal Information", FontWeight = FontWeights.Bold, Margin = new Thickness(0, 0, 0, 10) });
            reviewStack.Children.Add(new TextBlock { Text = "Name: John Doe" });
            reviewStack.Children.Add(new TextBlock { Text = "Email: john@example.com" });
            reviewStack.Children.Add(new TextBlock { Text = "Address", FontWeight = FontWeights.Bold, Margin = new Thickness(0, 15, 0, 10) });
            reviewStack.Children.Add(new TextBlock { Text = "123 Main St" });
            reviewStack.Children.Add(new TextBlock { Text = "New York, NY 10001" });
            reviewBorder.Child = reviewStack;
            step3Stack.Children.Add(reviewBorder);
            var btnPanel3 = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, 20, 0, 0) };
            var backBtn3 = new Button { Content = "← Back", Padding = new Thickness(15, 8), Margin = new Thickness(0, 0, 10, 0) };
            backBtn3.Click += (s, ev) => { tabControl.SelectedIndex = 1; };
            var submitBtn = new Button { Content = "Submit ✓", Padding = new Thickness(15, 8), Background = Brushes.Green, Foreground = Brushes.White };
            submitBtn.Click += (s, ev) => { MessageBox.Show("Registration complete!", "Success"); };
            btnPanel3.Children.Add(backBtn3);
            btnPanel3.Children.Add(submitBtn);
            step3Stack.Children.Add(btnPanel3);
            step3Tab.Content = step3Stack;
            tabControl.Items.Add(step3Tab);

            mainStack.Children.Add(tabControl);
            UpdateContent(mainStack);
        }

        private void ShowDashboard(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 7: Dashboard Application");

            AddDescription(mainStack, "Analytics dashboard with multiple views:");

            var tabControl = new System.Windows.Controls.TabControl
            {
                Height = 400,
                TabStripPlacement = Dock.Left,
                Margin = new Thickness(0, 10, 0, 0)
            };

            // Overview
            var overviewTab = new TabItem();
            var overviewHeader = new StackPanel { Width = 120 };
            overviewHeader.Children.Add(new TextBlock { Text = "📊 Overview", FontWeight = FontWeights.Bold });
            overviewHeader.Children.Add(new TextBlock { Text = "Summary", FontSize = 9, Foreground = Brushes.Gray });
            overviewTab.Header = overviewHeader;
            var overviewScroll = new ScrollViewer();
            var overviewStack = new StackPanel { Margin = new Thickness(20) };
            overviewStack.Children.Add(new TextBlock { Text = "Dashboard Overview", FontSize = 20, FontWeight = FontWeights.Bold, Margin = new Thickness(0, 0, 0, 20) });
            var statsGrid = new UniformGrid { Rows = 2, Columns = 2 };

            // Stat cards
            var card1 = CreateStatCard("Total Users", "12,547", "↑ 12% from last month", "#E3F2FD");
            var card2 = CreateStatCard("Revenue", "$45,231", "↑ 8% from last month", "#E8F5E9");
            var card3 = CreateStatCard("Active Sessions", "1,234", "↓ 3% from last month", "#FFF3E0");
            var card4 = CreateStatCard("Conversion Rate", "3.2%", "↑ 0.3% from last month", "#F3E5F5");

            statsGrid.Children.Add(card1);
            statsGrid.Children.Add(card2);
            statsGrid.Children.Add(card3);
            statsGrid.Children.Add(card4);
            overviewStack.Children.Add(statsGrid);
            overviewScroll.Content = overviewStack;
            overviewTab.Content = overviewScroll;
            tabControl.Items.Add(overviewTab);

            // Analytics
            var analyticsTab = new TabItem();
            var analyticsHeader = new StackPanel { Width = 120 };
            analyticsHeader.Children.Add(new TextBlock { Text = "📈 Analytics", FontWeight = FontWeights.Bold });
            analyticsHeader.Children.Add(new TextBlock { Text = "Detailed stats", FontSize = 9, Foreground = Brushes.Gray });
            analyticsTab.Header = analyticsHeader;
            analyticsTab.Content = new TextBlock { Text = "Analytics charts would appear here", Margin = new Thickness(20), VerticalAlignment = VerticalAlignment.Center };
            tabControl.Items.Add(analyticsTab);

            // Reports
            var reportsTab = new TabItem();
            var reportsHeader = new StackPanel { Width = 120 };
            reportsHeader.Children.Add(new TextBlock { Text = "📄 Reports", FontWeight = FontWeights.Bold });
            reportsHeader.Children.Add(new TextBlock { Text = "Generate reports", FontSize = 9, Foreground = Brushes.Gray });
            reportsTab.Header = reportsHeader;
            var reportsStack = new StackPanel { Margin = new Thickness(20) };
            reportsStack.Children.Add(new TextBlock { Text = "Available Reports", FontSize = 18, FontWeight = FontWeights.Bold, Margin = new Thickness(0, 0, 0, 15) });
            var report1 = new Border { Background = (Brush)new BrushConverter().ConvertFrom("#E3F2FD"), Padding = new Thickness(15), CornerRadius = new CornerRadius(5), Margin = new Thickness(0, 0, 0, 10) };
            var report1Stack = new StackPanel();
            report1Stack.Children.Add(new TextBlock { Text = "Monthly Report", FontWeight = FontWeights.Bold });
            report1Stack.Children.Add(new TextBlock { Text = "Generated: Nov 25, 2025", FontSize = 10, Foreground = Brushes.Gray });
            report1.Child = report1Stack;
            reportsStack.Children.Add(report1);
            reportsTab.Content = reportsStack;
            tabControl.Items.Add(reportsTab);

            mainStack.Children.Add(tabControl);
            UpdateContent(mainStack);
        }

        private void ShowStyledTabControl(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 8: Styled TabControl");

            AddDescription(mainStack, "Custom styled TabControl with colored tabs:");

            var tabControl = new System.Windows.Controls.TabControl
            {
                Height = 300,
                Background = (Brush)new BrushConverter().ConvertFrom("#F5F5F5"),
                BorderBrush = (Brush)new BrushConverter().ConvertFrom("#CCCCCC"),
                BorderThickness = new Thickness(1),
                Margin = new Thickness(0, 10, 0, 0)
            };

            // Active Tab (Green)
            var activeTab = new TabItem();
            var activeBorder = new Border
            {
                Background = (Brush)new BrushConverter().ConvertFrom("#4CAF50"),
                CornerRadius = new CornerRadius(3),
                Padding = new Thickness(10, 5)
            };
            activeBorder.Child = new TextBlock { Text = "Active", Foreground = Brushes.White, FontWeight = FontWeights.Bold };
            activeTab.Header = activeBorder;
            activeTab.Content = new TextBlock { Text = "Active projects content", Margin = new Thickness(20), VerticalAlignment = VerticalAlignment.Center };
            tabControl.Items.Add(activeTab);

            // Pending Tab (Orange)
            var pendingTab = new TabItem();
            var pendingBorder = new Border
            {
                Background = (Brush)new BrushConverter().ConvertFrom("#FF9800"),
                CornerRadius = new CornerRadius(3),
                Padding = new Thickness(10, 5)
            };
            pendingBorder.Child = new TextBlock { Text = "Pending", Foreground = Brushes.White, FontWeight = FontWeights.Bold };
            pendingTab.Header = pendingBorder;
            pendingTab.Content = new TextBlock { Text = "Pending tasks content", Margin = new Thickness(20), VerticalAlignment = VerticalAlignment.Center };
            tabControl.Items.Add(pendingTab);

            // Completed Tab (Blue)
            var completedTab = new TabItem();
            var completedBorder = new Border
            {
                Background = (Brush)new BrushConverter().ConvertFrom("#2196F3"),
                CornerRadius = new CornerRadius(3),
                Padding = new Thickness(10, 5)
            };
            completedBorder.Child = new TextBlock { Text = "Completed", Foreground = Brushes.White, FontWeight = FontWeights.Bold };
            completedTab.Header = completedBorder;
            completedTab.Content = new TextBlock { Text = "Completed items content", Margin = new Thickness(20), VerticalAlignment = VerticalAlignment.Center };
            tabControl.Items.Add(completedTab);

            // Archive Tab (Gray)
            var archiveTab = new TabItem();
            var archiveBorder = new Border
            {
                Background = (Brush)new BrushConverter().ConvertFrom("#9E9E9E"),
                CornerRadius = new CornerRadius(3),
                Padding = new Thickness(10, 5)
            };
            archiveBorder.Child = new TextBlock { Text = "Archive", Foreground = Brushes.White, FontWeight = FontWeights.Bold };
            archiveTab.Header = archiveBorder;
            archiveTab.Content = new TextBlock { Text = "Archived items content", Margin = new Thickness(20), VerticalAlignment = VerticalAlignment.Center };
            tabControl.Items.Add(archiveTab);

            mainStack.Children.Add(tabControl);
            UpdateContent(mainStack);
        }

        private void ShowAdvanced(object sender, RoutedEventArgs e)
        {
            var mainStack = CreateMainStack("Demo 9: Advanced Features");

            AddDescription(mainStack, "Dynamic tab creation, tab events, and programmatic control:");

            var tabControl = new System.Windows.Controls.TabControl
            {
                Height = 350,
                Margin = new Thickness(0, 10, 0, 0),
                Name = "AdvancedTabControl"
            };

            // Add initial tabs
            for (int i = 1; i <= 3; i++)
            {
                var tab = new TabItem { Header = $"Tab {i}" };
                tab.Content = new TextBlock { Text = $"Content for Tab {i}", Margin = new Thickness(20), VerticalAlignment = VerticalAlignment.Center };
                tabControl.Items.Add(tab);
            }

            // Selection changed event
            tabControl.SelectionChanged += (s, ev) =>
            {
                if (ev.Source is System.Windows.Controls.TabControl tc && tc.SelectedItem is TabItem selectedTab)
                {
                    // Could update status bar or load data here
                }
            };

            mainStack.Children.Add(tabControl);

            // Control buttons
            var controlPanel = new WrapPanel { Margin = new Thickness(0, 10, 0, 0) };

            var addBtn = new Button { Content = "+ Add Tab", Padding = new Thickness(10, 5), Margin = new Thickness(5) };
            addBtn.Click += (s, ev) =>
            {
                int newIndex = tabControl.Items.Count + 1;
                var newTab = new TabItem { Header = $"Tab {newIndex}" };
                newTab.Content = new TextBox
                {
                    AcceptsReturn = true,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(10),
                    Text = $"This is a dynamically created tab #{newIndex}\n\nYou can edit this content..."
                };
                tabControl.Items.Add(newTab);
                tabControl.SelectedItem = newTab;
            };
            controlPanel.Children.Add(addBtn);

            var removeBtn = new Button { Content = "- Remove Current", Padding = new Thickness(10, 5), Margin = new Thickness(5) };
            removeBtn.Click += (s, ev) =>
            {
                if (tabControl.SelectedItem != null && tabControl.Items.Count > 1)
                {
                    tabControl.Items.Remove(tabControl.SelectedItem);
                }
            };
            controlPanel.Children.Add(removeBtn);

            var selectFirstBtn = new Button { Content = "Select First", Padding = new Thickness(10, 5), Margin = new Thickness(5) };
            selectFirstBtn.Click += (s, ev) => { tabControl.SelectedIndex = 0; };
            controlPanel.Children.Add(selectFirstBtn);

            var selectLastBtn = new Button { Content = "Select Last", Padding = new Thickness(10, 5), Margin = new Thickness(5) };
            selectLastBtn.Click += (s, ev) => { tabControl.SelectedIndex = tabControl.Items.Count - 1; };
            controlPanel.Children.Add(selectLastBtn);

            mainStack.Children.Add(controlPanel);

            UpdateContent(mainStack);
        }

        // Helper methods
        private StackPanel CreateMainStack(string title)
        {
            var stack = new StackPanel();
            stack.Children.Add(new TextBlock
            {
                Text = title,
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 0, 10)
            });
            return stack;
        }

        private void AddDescription(StackPanel parent, string text)
        {
            parent.Children.Add(new TextBlock
            {
                Text = text,
                FontSize = 14,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(0, 0, 0, 10)
            });
        }

        private System.Windows.Controls.TabControl CreateSimpleTabControl(Dock position)
        {
            var tabControl = new System.Windows.Controls.TabControl
            {
                TabStripPlacement = position,
                Height = 200
            };

            var label = new Border
            {
                Background = (Brush)new BrushConverter().ConvertFrom("#E3F2FD"),
                Padding = new Thickness(10),
                CornerRadius = new CornerRadius(5)
            };
            label.Child = new TextBlock
            {
                Text = $"TabStripPlacement = {position}",
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            var tab1 = new TabItem { Header = "Tab 1" };
            tab1.Content = label;
            tabControl.Items.Add(tab1);

            var tab2 = new TabItem { Header = "Tab 2", Content = new TextBlock { Text = "Content 2", Margin = new Thickness(10) } };
            tabControl.Items.Add(tab2);

            var tab3 = new TabItem { Header = "Tab 3", Content = new TextBlock { Text = "Content 3", Margin = new Thickness(10) } };
            tabControl.Items.Add(tab3);

            return tabControl;
        }

        private Border CreateStatCard(string title, string value, string change, string bgColor)
        {
            var card = new Border
            {
                Background = (Brush)new BrushConverter().ConvertFrom(bgColor),
                Margin = new Thickness(5),
                Padding = new Thickness(20),
                CornerRadius = new CornerRadius(5)
            };

            var stack = new StackPanel();
            stack.Children.Add(new TextBlock { Text = title, FontSize = 12, Foreground = Brushes.Gray });
            stack.Children.Add(new TextBlock { Text = value, FontSize = 32, FontWeight = FontWeights.Bold });

            var changeColor = change.Contains("↑") ? Brushes.Green : Brushes.Red;
            stack.Children.Add(new TextBlock { Text = change, FontSize = 10, Foreground = changeColor });

            card.Child = stack;
            return card;
        }

        private void UpdateContent(StackPanel content)
        {
            var container = new Border
            {
                Background = Brushes.White,
                Margin = new Thickness(20),
                Padding = new Thickness(30),
                CornerRadius = new CornerRadius(10)
            };
            container.Child = content;
            ContentPanel.Content = container;
        }
    }
}
