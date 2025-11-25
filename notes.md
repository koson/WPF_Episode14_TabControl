# Episode 14: TabControl - Quick Reference

> 💡 **Core Concept**: Multi-page interface in single space - solve the "too many sections" problem!

---

## 🎯 The Problem TabControl Solves

**Before TabControl:**
```xml
<!-- Problem: Everything stacked vertically = LONG SCROLL! -->
<StackPanel>
    <GroupBox Header="General Settings" Height="300"/>
    <GroupBox Header="Appearance" Height="250"/>
    <GroupBox Header="Privacy" Height="280"/>
    <GroupBox Header="Notifications" Height="200"/>
    <!-- User must scroll a lot! 😢 -->
</StackPanel>
```

**After TabControl:**
```xml
<!-- Solution: Same space, multiple pages! -->
<TabControl>
    <TabItem Header="General"/>
    <TabItem Header="Appearance"/>
    <TabItem Header="Privacy"/>
    <TabItem Header="Notifications"/>
    <!-- Click to switch - NO SCROLL! 😊 -->
</TabControl>
```

---

## 📋 Basic Syntax

### Minimal TabControl
```xml
<TabControl>
    <TabItem Header="Home">
        <TextBlock Text="Home content"/>
    </TabItem>
    <TabItem Header="Settings">
        <TextBlock Text="Settings content"/>
    </TabItem>
</TabControl>
```

### With Icons
```xml
<TabControl>
    <TabItem Header="🏠 Home">
        <TextBlock Text="Welcome!"/>
    </TabItem>
    <TabItem Header="⚙️ Settings">
        <TextBlock Text="Configure here"/>
    </TabItem>
</TabControl>
```

---

## 🔧 Essential Properties

### TabControl Properties
```xml
<TabControl SelectedIndex="0"                    <!-- Current tab (0-based) -->
            TabStripPlacement="Top"              <!-- Top|Bottom|Left|Right -->
            Background="White"
            SelectionChanged="TabControl_SelectionChanged">
```

### TabItem Properties
```xml
<TabItem Header="My Tab"                         <!-- Simple text header -->
         IsSelected="True"                       <!-- Is this tab active? -->
         Foreground="Blue"
         FontWeight="Bold">
```

---

## 💡 Common Patterns

### Pattern 1: Settings Panel (Most Common!)
```xml
<TabControl Height="400">
    <TabItem Header="⚙️ General">
        <GroupBox Header="Startup" Padding="10">
            <StackPanel>
                <CheckBox Content="Launch on startup"/>
                <CheckBox Content="Check for updates"/>
            </StackPanel>
        </GroupBox>
    </TabItem>
    
    <TabItem Header="🎨 Appearance">
        <GroupBox Header="Theme" Padding="10">
            <StackPanel>
                <RadioButton Content="Light" IsChecked="True"/>
                <RadioButton Content="Dark"/>
            </StackPanel>
        </GroupBox>
    </TabItem>
</TabControl>
```

### Pattern 2: Custom Header with Badge
```xml
<TabItem>
    <TabItem.Header>
        <StackPanel Orientation="Horizontal">
            <TextBlock Text="📧 Messages" 
                       VerticalAlignment="Center"/>
            <Border Background="Red" 
                    CornerRadius="10" 
                    Padding="5,2" 
                    Margin="5,0">
                <TextBlock Text="12" 
                           Foreground="White" 
                           FontSize="11"/>
            </Border>
        </StackPanel>
    </TabItem.Header>
    <TextBlock Text="12 new messages!"/>
</TabItem>
```

### Pattern 3: Multi-step Form
```xml
<TabControl>
    <TabItem Header="1️⃣ Personal Info">
        <!-- Form fields -->
        <Button Content="Next →" HorizontalAlignment="Right"/>
    </TabItem>
    
    <TabItem Header="2️⃣ Address">
        <!-- Address fields -->
        <StackPanel Orientation="Horizontal" HorizontalAlignment="Right">
            <Button Content="← Back"/>
            <Button Content="Next →"/>
        </StackPanel>
    </TabItem>
    
    <TabItem Header="3️⃣ Confirm">
        <!-- Review data -->
        <Button Content="Submit ✓" Background="Green"/>
    </TabItem>
</TabControl>
```

---

## 🎨 Styling

### Background Colors
```xml
<TabControl Background="LightGray">
    <TabItem Header="Tab 1" Background="White">
        <Border Background="AliceBlue" Padding="20">
            <TextBlock Text="Content"/>
        </Border>
    </TabItem>
</TabControl>
```

### Tab Placement
```xml
<!-- Tabs on Top (default) -->
<TabControl TabStripPlacement="Top"/>

<!-- Tabs on Left (sidebar style) -->
<TabControl TabStripPlacement="Left"/>

<!-- Tabs on Bottom -->
<TabControl TabStripPlacement="Bottom"/>

<!-- Tabs on Right -->
<TabControl TabStripPlacement="Right"/>
```

---

## 💻 Code Behind

### Control Selected Tab
```csharp
// Change tab programmatically
MyTabControl.SelectedIndex = 2;  // Switch to 3rd tab

// Get current tab
int current = MyTabControl.SelectedIndex;
TabItem selectedTab = (TabItem)MyTabControl.SelectedItem;
```

### Handle Tab Change
```csharp
private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    if (e.Source is TabControl tabControl)
    {
        var selectedTab = tabControl.SelectedItem as TabItem;
        if (selectedTab != null)
        {
            Debug.WriteLine($"Switched to: {selectedTab.Header}");
        }
    }
}
```

### Navigate with Buttons
```xml
<Button Content="Go to Settings" Click="GoToSettings_Click"/>
```

```csharp
private void GoToSettings_Click(object sender, RoutedEventArgs e)
{
    MyTabControl.SelectedIndex = 1;  // Settings tab
}
```

---

## ⚠️ Common Problems & Solutions

### Problem 1: Content Overflows Tab
```xml
<!-- ❌ Problem: Long content cut off -->
<TabItem Header="Info">
    <StackPanel>
        <!-- 50 lines of content = can't see all! -->
    </StackPanel>
</TabItem>

<!-- ✅ Solution: Add ScrollViewer -->
<TabItem Header="Info">
    <ScrollViewer VerticalScrollBarVisibility="Auto">
        <StackPanel>
            <!-- Now can scroll! 😊 -->
        </StackPanel>
    </ScrollViewer>
</TabItem>
```

### Problem 2: Too Many Tabs
```xml
<!-- ❌ Bad: 15 tabs - overwhelming! -->
<TabControl>
    <TabItem Header="Tab1"/>
    <TabItem Header="Tab2"/>
    <!-- ... 13 more tabs ... -->
</TabControl>

<!-- ✅ Good: Max 5-7 tabs, group related items -->
<TabControl>
    <TabItem Header="General">
        <!-- Multiple GroupBoxes inside -->
    </TabItem>
    <TabItem Header="Advanced">
        <!-- Advanced options -->
    </TabItem>
</TabControl>
```

### Problem 3: Unclear Tab Labels
```xml
<!-- ❌ Bad: Not clear -->
<TabItem Header="Tab1"/>
<TabItem Header="Tab2"/>

<!-- ✅ Good: Clear with icons -->
<TabItem Header="🏠 Home"/>
<TabItem Header="⚙️ Settings"/>
<TabItem Header="ℹ️ About"/>
```

---

## 🎯 When to Use TabControl

### ✅ Perfect For:
- **Settings Panels** - Multiple setting categories
- **Multi-step Forms** - Wizard-like interfaces
- **Dashboards** - Different data views
- **Document Editors** - Multiple open documents
- **Browser-like Apps** - Multiple pages/tabs

### ❌ Don't Use For:
- **Single section** - Use StackPanel/Grid
- **Dynamic list** - Use ListBox/DataGrid
- **Overflow content only** - Use ScrollViewer
- **Simple grouping** - Use GroupBox

---

## 📊 Quick Comparison

| Feature | TabControl | Expander | GroupBox |
|---------|-----------|----------|----------|
| Purpose | Multi-page | Collapsible | Grouping |
| Space | Shows one at a time | All visible when expanded | All visible |
| Navigation | Click tabs | Click header | No navigation |
| Use case | Settings, Forms | FAQ, Optional info | Related controls |

---

## 🚀 Real-World Example

### Complete Settings Dialog
```xml
<Window Title="Application Settings" Width="600" Height="500">
    <TabControl Margin="10">
        <!-- General Tab -->
        <TabItem Header="⚙️ General">
            <ScrollViewer>
                <StackPanel Margin="20">
                    <GroupBox Header="Startup" Padding="10" Margin="0,0,0,10">
                        <StackPanel>
                            <CheckBox Content="Launch on startup" IsChecked="True"/>
                            <CheckBox Content="Minimize to tray"/>
                            <CheckBox Content="Check for updates" IsChecked="True"/>
                        </StackPanel>
                    </GroupBox>
                    
                    <GroupBox Header="Language" Padding="10">
                        <ComboBox SelectedIndex="0">
                            <ComboBoxItem Content="English"/>
                            <ComboBoxItem Content="ไทย"/>
                        </ComboBox>
                    </GroupBox>
                </StackPanel>
            </ScrollViewer>
        </TabItem>
        
        <!-- Appearance Tab -->
        <TabItem Header="🎨 Appearance">
            <ScrollViewer>
                <StackPanel Margin="20">
                    <GroupBox Header="Theme" Padding="10" Margin="0,0,0,10">
                        <StackPanel>
                            <RadioButton Content="Light" IsChecked="True"/>
                            <RadioButton Content="Dark"/>
                            <RadioButton Content="Auto"/>
                        </StackPanel>
                    </GroupBox>
                    
                    <GroupBox Header="Font" Padding="10">
                        <StackPanel>
                            <TextBlock Text="Font Size:"/>
                            <Slider Minimum="10" Maximum="24" Value="14"/>
                        </StackPanel>
                    </GroupBox>
                </StackPanel>
            </ScrollViewer>
        </TabItem>
        
        <!-- About Tab -->
        <TabItem Header="ℹ️ About">
            <StackPanel Margin="20" VerticalAlignment="Center">
                <TextBlock Text="My Application" 
                           FontSize="24" 
                           FontWeight="Bold"
                           HorizontalAlignment="Center"/>
                <TextBlock Text="Version 1.0.0" 
                           HorizontalAlignment="Center"
                           Margin="0,10"/>
                <Button Content="Check for Updates" 
                        HorizontalAlignment="Center"
                        Margin="0,20"/>
            </StackPanel>
        </TabItem>
    </TabControl>
</Window>
```

---

## ✅ Best Practices Checklist

- [ ] Limit to 5-7 tabs maximum
- [ ] Use clear, descriptive headers
- [ ] Add icons to headers
- [ ] Include ScrollViewer for long content
- [ ] Set SelectedIndex="0" for default tab
- [ ] Use TabStripPlacement appropriately
- [ ] Group related settings together
- [ ] Add navigation buttons for wizards

---

## 🎓 Progressive Learning Path

1. **Basic** - Simple TabControl with text
2. **Icons** - Add emoji/icons to headers
3. **Custom Headers** - Rich header content with badges
4. **Settings Panel** - Complete settings with GroupBox
5. **Multi-step Form** - Wizard with Next/Back buttons
6. **Code Behind** - Programmatic tab switching
7. **Advanced** - Dynamic tabs, validation

---

## 📝 Key Takeaways

✅ **TabControl** = Multi-page interface in same space  
✅ **Saves screen space** - One page at a time  
✅ **Easy navigation** - Click tabs to switch  
✅ **Perfect for settings** - Multiple categories  
✅ **Limit tabs** - Max 5-7 for usability  
✅ **Use ScrollViewer** - For long content  
✅ **Clear labels** - With icons when possible  

---

## 🔗 Related Topics

- **Previous**: Episode 13 - GroupBox (organize within tabs)
- **Complements**: ScrollViewer (scroll within tabs)
- **Alternative**: Expander (collapsible sections)
- **Next**: Advanced UI Patterns

---

## 📚 Resources

- [Full Script](SCRIPT.md) - Complete tutorial with timestamps
- [Complete Guide](README.md) - Detailed documentation
- [Official Docs](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.tabcontrol)

---

**Quick Reference Version 1.0** | Last Updated: Nov 24, 2025
