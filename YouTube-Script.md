# สคริปต์การสอน: WPF Episode 14 - TabControl

## เนื้อหาที่จะสอน

### 1. TabControl คืออะไร
- Control สำหรับสร้าง Multi-page Interface
- แสดงหลายหน้าในพื้นที่เดียวกัน
- ใช้ Tab สำหรับสลับหน้า

### 2. TabControl Components
- TabControl - Container หลัก
- TabItem - แต่ละ Tab
- Header - หัวข้อ Tab
- Content - เนื้อหาในแต่ละ Tab

### 3. การใช้งาน
- Multi-section Application
- Settings Panel
- Document Editor
- Dashboard with multiple views

---

## ส่วนที่ 1: Introduction (0:00 - 2:00)

**สวัสดีครับทุกคน**

ยินดีต้อนรับกลับมาสู่ WPF Tutorial Series ของเรา

วันนี้เป็นตอนสุดท้ายของ Layout Series! เราจะมาเรียนรู้เกี่ยวกับ **TabControl**!

TabControl ทำอะไร?
- สร้าง Multi-page Interface
- แสดงหลายหน้าในพื้นที่เดียวกัน
- ใช้ Tab สำหรับสลับหน้า

**คิดเหมือนกับสมุดที่มีหลาย Tab!**

เหมาะมากสำหรับแอพที่มีหลายส่วน เช่น Settings, Browser, Document Editor!

---

## ส่วนที่ 2: TabControl พื้นฐาน (2:00 - 6:00)

### Demo 2.1: Basic TabControl

```xml
<TabControl>
    <TabItem Header="Home">
        <TextBlock Text="Welcome to Home page!" 
                   HorizontalAlignment="Center" 
                   VerticalAlignment="Center" 
                   FontSize="20"/>
    </TabItem>
    
    <TabItem Header="Profile">
        <TextBlock Text="This is Profile page" 
                   HorizontalAlignment="Center" 
                   VerticalAlignment="Center" 
                   FontSize="20"/>
    </TabItem>
    
    <TabItem Header="Settings">
        <TextBlock Text="Settings page here" 
                   HorizontalAlignment="Center" 
                   VerticalAlignment="Center" 
                   FontSize="20"/>
    </TabItem>
</TabControl>
```

**อธิบาย:**
- `TabControl` - Container หลัก
- `TabItem` - แต่ละ Tab
- `Header` - ชื่อ Tab
- คลิก Tab เพื่อสลับหน้า

### Demo 2.2: TabControl with Icons

```xml
<TabControl>
    <TabItem Header="🏠 Home">
        <TextBlock Text="Home Content" Margin="20"/>
    </TabItem>
    
    <TabItem Header="👤 Profile">
        <TextBlock Text="Profile Content" Margin="20"/>
    </TabItem>
    
    <TabItem Header="⚙️ Settings">
        <TextBlock Text="Settings Content" Margin="20"/>
    </TabItem>
    
    <TabItem Header="📧 Messages">
        <TextBlock Text="Messages Content" Margin="20"/>
    </TabItem>
</TabControl>
```

Icon ทำให้ Tab ดูชัดเจนขึ้น!

---

## ส่วนที่ 3: Custom Header (6:00 - 10:00)

### Demo 3.1: Rich Header

```xml
<TabControl>
    <TabItem>
        <TabItem.Header>
            <StackPanel Orientation="Horizontal">
                <TextBlock Text="🏠" FontSize="20" Margin="0,0,5,0"/>
                <TextBlock Text="Home" 
                           FontWeight="Bold" 
                           VerticalAlignment="Center"/>
            </StackPanel>
        </TabItem.Header>
        <TextBlock Text="Home Content" Margin="20"/>
    </TabItem>
    
    <TabItem>
        <TabItem.Header>
            <StackPanel Orientation="Horizontal">
                <TextBlock Text="📊" FontSize="20" Margin="0,0,5,0"/>
                <StackPanel>
                    <TextBlock Text="Dashboard" FontWeight="Bold"/>
                    <TextBlock Text="View stats" 
                               FontSize="10" 
                               Foreground="Gray"/>
                </StackPanel>
            </StackPanel>
        </TabItem.Header>
        <TextBlock Text="Dashboard Content" Margin="20"/>
    </TabItem>
</TabControl>
```

### Demo 3.2: Header with Badge

```xml
<TabControl>
    <TabItem>
        <TabItem.Header>
            <StackPanel Orientation="Horizontal">
                <TextBlock Text="📧 Messages" 
                           FontWeight="Bold" 
                           VerticalAlignment="Center"/>
                <Border Background="Red" 
                        CornerRadius="10" 
                        Padding="5,2" 
                        Margin="5,0">
                    <TextBlock Text="12" 
                               Foreground="White" 
                               FontSize="11" 
                               FontWeight="Bold"/>
                </Border>
            </StackPanel>
        </TabItem.Header>
        <TextBlock Text="You have 12 new messages!" Margin="20"/>
    </TabItem>
    
    <TabItem Header="🔔 Notifications">
        <TextBlock Text="Notifications here" Margin="20"/>
    </TabItem>
</TabControl>
```

Badge แสดงจำนวนข้อความใหม่!

---

## ส่วนที่ 4: Settings Panel (10:00 - 16:00)

### Demo 4.1: Complete Settings

```xml
<TabControl Height="400">
    <TabItem Header="⚙️ General">
        <ScrollViewer VerticalScrollBarVisibility="Auto">
            <StackPanel Margin="20">
                <TextBlock Text="General Settings" 
                           FontSize="20" 
                           FontWeight="Bold" 
                           Margin="0,0,0,15"/>
                
                <GroupBox Header="Startup" Padding="10" Margin="0,5">
                    <StackPanel>
                        <CheckBox Content="Launch on startup" IsChecked="True"/>
                        <CheckBox Content="Minimize to tray" Margin="0,5"/>
                        <CheckBox Content="Check for updates" IsChecked="True" Margin="0,5"/>
                    </StackPanel>
                </GroupBox>
                
                <GroupBox Header="Language" Padding="10" Margin="0,10">
                    <ComboBox SelectedIndex="0">
                        <ComboBoxItem Content="English"/>
                        <ComboBoxItem Content="ไทย"/>
                        <ComboBoxItem Content="日本語"/>
                    </ComboBox>
                </GroupBox>
            </StackPanel>
        </ScrollViewer>
    </TabItem>
    
    <TabItem Header="🎨 Appearance">
        <ScrollViewer VerticalScrollBarVisibility="Auto">
            <StackPanel Margin="20">
                <TextBlock Text="Appearance Settings" 
                           FontSize="20" 
                           FontWeight="Bold" 
                           Margin="0,0,0,15"/>
                
                <GroupBox Header="Theme" Padding="10" Margin="0,5">
                    <StackPanel>
                        <RadioButton Content="Light" IsChecked="True" Margin="5"/>
                        <RadioButton Content="Dark" Margin="5"/>
                        <RadioButton Content="Auto" Margin="5"/>
                    </StackPanel>
                </GroupBox>
                
                <GroupBox Header="Font" Padding="10" Margin="0,10">
                    <StackPanel>
                        <TextBlock Text="Font Size:"/>
                        <Slider Minimum="10" 
                                Maximum="24" 
                                Value="14" 
                                TickFrequency="2" 
                                IsSnapToTickEnabled="True" 
                                Margin="0,5"/>
                        
                        <TextBlock Text="Font Family:" Margin="0,10,0,5"/>
                        <ComboBox SelectedIndex="0">
                            <ComboBoxItem Content="Segoe UI"/>
                            <ComboBoxItem Content="Arial"/>
                            <ComboBoxItem Content="Calibri"/>
                        </ComboBox>
                    </StackPanel>
                </GroupBox>
            </StackPanel>
        </ScrollViewer>
    </TabItem>
    
    <TabItem Header="🔒 Privacy">
        <ScrollViewer VerticalScrollBarVisibility="Auto">
            <StackPanel Margin="20">
                <TextBlock Text="Privacy Settings" 
                           FontSize="20" 
                           FontWeight="Bold" 
                           Margin="0,0,0,15"/>
                
                <GroupBox Header="Data Collection" Padding="10" Margin="0,5">
                    <StackPanel>
                        <CheckBox Content="Share usage data"/>
                        <CheckBox Content="Allow crash reports" IsChecked="True" Margin="0,5"/>
                        <CheckBox Content="Personalized ads" Margin="0,5"/>
                    </StackPanel>
                </GroupBox>
                
                <GroupBox Header="Cookies" Padding="10" Margin="0,10">
                    <StackPanel>
                        <RadioButton Content="Accept all" IsChecked="True" Margin="5"/>
                        <RadioButton Content="Essential only" Margin="5"/>
                        <RadioButton Content="Block all" Margin="5"/>
                    </StackPanel>
                </GroupBox>
            </StackPanel>
        </ScrollViewer>
    </TabItem>
    
    <TabItem Header="🔔 Notifications">
        <ScrollViewer VerticalScrollBarVisibility="Auto">
            <StackPanel Margin="20">
                <TextBlock Text="Notification Settings" 
                           FontSize="20" 
                           FontWeight="Bold" 
                           Margin="0,0,0,15"/>
                
                <GroupBox Header="Email Notifications" Padding="10" Margin="0,5">
                    <StackPanel>
                        <CheckBox Content="New messages" IsChecked="True"/>
                        <CheckBox Content="Updates" IsChecked="True" Margin="0,5"/>
                        <CheckBox Content="Promotions" Margin="0,5"/>
                    </StackPanel>
                </GroupBox>
                
                <GroupBox Header="Push Notifications" Padding="10" Margin="0,10">
                    <StackPanel>
                        <CheckBox Content="Enable push notifications" IsChecked="True"/>
                        <CheckBox Content="Sound" IsChecked="True" Margin="0,5"/>
                        <CheckBox Content="Vibration" Margin="0,5"/>
                    </StackPanel>
                </GroupBox>
            </StackPanel>
        </ScrollViewer>
    </TabItem>
</TabControl>
```

Settings แบ่งเป็น 4 Tab ชัดเจน!

---

## ส่วนที่ 5: Form with Tabs (16:00 - 20:00)

### Demo 5.1: Multi-step Form

```xml
<TabControl>
    <TabItem Header="1️⃣ Personal Info">
        <StackPanel Margin="20">
            <TextBlock Text="Personal Information" 
                       FontSize="20" 
                       FontWeight="Bold" 
                       Margin="0,0,0,15"/>
            
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="Auto"/>
                </Grid.RowDefinitions>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="Auto"/>
                    <ColumnDefinition Width="*"/>
                </Grid.ColumnDefinitions>
                
                <TextBlock Grid.Row="0" Grid.Column="0" 
                           Text="First Name:" 
                           VerticalAlignment="Center" 
                           Margin="0,5,10,5"/>
                <TextBox Grid.Row="0" Grid.Column="1" 
                         Padding="5" 
                         Margin="0,5"/>
                
                <TextBlock Grid.Row="1" Grid.Column="0" 
                           Text="Last Name:" 
                           VerticalAlignment="Center" 
                           Margin="0,5,10,5"/>
                <TextBox Grid.Row="1" Grid.Column="1" 
                         Padding="5" 
                         Margin="0,5"/>
                
                <TextBlock Grid.Row="2" Grid.Column="0" 
                           Text="Email:" 
                           VerticalAlignment="Center" 
                           Margin="0,5,10,5"/>
                <TextBox Grid.Row="2" Grid.Column="1" 
                         Padding="5" 
                         Margin="0,5"/>
            </Grid>
            
            <Button Content="Next →" 
                    HorizontalAlignment="Right" 
                    Padding="20,10" 
                    Margin="0,20"/>
        </StackPanel>
    </TabItem>
    
    <TabItem Header="2️⃣ Address">
        <StackPanel Margin="20">
            <TextBlock Text="Address Information" 
                       FontSize="20" 
                       FontWeight="Bold" 
                       Margin="0,0,0,15"/>
            
            <TextBlock Text="Street:"/>
            <TextBox Padding="5" Margin="0,5,0,10"/>
            
            <TextBlock Text="City:"/>
            <TextBox Padding="5" Margin="0,5,0,10"/>
            
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*"/>
                    <ColumnDefinition Width="*"/>
                </Grid.ColumnDefinitions>
                
                <StackPanel Grid.Column="0" Margin="0,0,5,0">
                    <TextBlock Text="State:"/>
                    <ComboBox Padding="5" Margin="0,5"/>
                </StackPanel>
                
                <StackPanel Grid.Column="1" Margin="5,0,0,0">
                    <TextBlock Text="Zip Code:"/>
                    <TextBox Padding="5" Margin="0,5"/>
                </StackPanel>
            </Grid>
            
            <StackPanel Orientation="Horizontal" 
                        HorizontalAlignment="Right" 
                        Margin="0,20">
                <Button Content="← Back" Padding="20,10" Margin="0,0,10,0"/>
                <Button Content="Next →" Padding="20,10"/>
            </StackPanel>
        </StackPanel>
    </TabItem>
    
    <TabItem Header="3️⃣ Confirmation">
        <StackPanel Margin="20">
            <TextBlock Text="Review & Confirm" 
                       FontSize="20" 
                       FontWeight="Bold" 
                       Margin="0,0,0,15"/>
            
            <Border BorderBrush="Gray" 
                    BorderThickness="1" 
                    CornerRadius="5" 
                    Padding="15" 
                    Background="LightGray">
                <StackPanel>
                    <TextBlock Text="Personal Information" 
                               FontWeight="Bold" 
                               Margin="0,0,0,10"/>
                    <TextBlock Text="Name: John Doe"/>
                    <TextBlock Text="Email: john@example.com"/>
                    
                    <TextBlock Text="Address" 
                               FontWeight="Bold" 
                               Margin="0,15,0,10"/>
                    <TextBlock Text="123 Main St, City, State 12345"/>
                </StackPanel>
            </Border>
            
            <StackPanel Orientation="Horizontal" 
                        HorizontalAlignment="Right" 
                        Margin="0,20">
                <Button Content="← Back" Padding="20,10" Margin="0,0,10,0"/>
                <Button Content="Submit ✓" 
                        Background="Green" 
                        Foreground="White" 
                        Padding="20,10"/>
            </StackPanel>
        </StackPanel>
    </TabItem>
</TabControl>
```

Multi-step Form ด้วย TabControl!

---

## ส่วนที่ 6: Dashboard Example (20:00 - 25:00)

### Demo 6.1: Dashboard with Multiple Views

```xml
<TabControl Height="400">
    <TabItem Header="📊 Overview">
        <Grid Margin="20">
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            
            <TextBlock Grid.Row="0" 
                       Text="Dashboard Overview" 
                       FontSize="24" 
                       FontWeight="Bold" 
                       Margin="0,0,0,20"/>
            
            <UniformGrid Grid.Row="1" Rows="2" Columns="2">
                <Border Background="LightBlue" 
                        Margin="10" 
                        Padding="20" 
                        CornerRadius="10">
                    <StackPanel>
                        <TextBlock Text="💰 Revenue" 
                                   FontSize="16" 
                                   FontWeight="Bold"/>
                        <TextBlock Text="$45,678" 
                                   FontSize="32" 
                                   Foreground="Green" 
                                   Margin="0,10"/>
                        <TextBlock Text="+12% this month" 
                                   FontSize="12" 
                                   Foreground="Gray"/>
                    </StackPanel>
                </Border>
                
                <Border Background="LightGreen" 
                        Margin="10" 
                        Padding="20" 
                        CornerRadius="10">
                    <StackPanel>
                        <TextBlock Text="👥 Users" 
                                   FontSize="16" 
                                   FontWeight="Bold"/>
                        <TextBlock Text="1,234" 
                                   FontSize="32" 
                                   Foreground="Blue" 
                                   Margin="0,10"/>
                        <TextBlock Text="+8% this month" 
                                   FontSize="12" 
                                   Foreground="Gray"/>
                    </StackPanel>
                </Border>
                
                <Border Background="LightCoral" 
                        Margin="10" 
                        Padding="20" 
                        CornerRadius="10">
                    <StackPanel>
                        <TextBlock Text="📦 Orders" 
                                   FontSize="16" 
                                   FontWeight="Bold"/>
                        <TextBlock Text="456" 
                                   FontSize="32" 
                                   Foreground="DarkRed" 
                                   Margin="0,10"/>
                        <TextBlock Text="+5% this month" 
                                   FontSize="12" 
                                   Foreground="Gray"/>
                    </StackPanel>
                </Border>
                
                <Border Background="LightYellow" 
                        Margin="10" 
                        Padding="20" 
                        CornerRadius="10">
                    <StackPanel>
                        <TextBlock Text="⭐ Reviews" 
                                   FontSize="16" 
                                   FontWeight="Bold"/>
                        <TextBlock Text="4.8/5.0" 
                                   FontSize="32" 
                                   Foreground="Orange" 
                                   Margin="0,10"/>
                        <TextBlock Text="Based on 234 reviews" 
                                   FontSize="12" 
                                   Foreground="Gray"/>
                    </StackPanel>
                </Border>
            </UniformGrid>
        </Grid>
    </TabItem>
    
    <TabItem Header="📈 Analytics">
        <StackPanel Margin="20">
            <TextBlock Text="Analytics" 
                       FontSize="24" 
                       FontWeight="Bold" 
                       Margin="0,0,0,20"/>
            <TextBlock Text="Chart and analytics data would go here..." 
                       FontSize="16" 
                       Foreground="Gray"/>
        </StackPanel>
    </TabItem>
    
    <TabItem Header="📋 Reports">
        <StackPanel Margin="20">
            <TextBlock Text="Reports" 
                       FontSize="24" 
                       FontWeight="Bold" 
                       Margin="0,0,0,20"/>
            <ListBox>
                <ListBoxItem Content="📄 Monthly Report - October 2025"/>
                <ListBoxItem Content="📄 Quarterly Report - Q3 2025"/>
                <ListBoxItem Content="📄 Annual Report - 2024"/>
            </ListBox>
        </StackPanel>
    </TabItem>
</TabControl>
```

---

## ส่วนที่ 7: Properties และ Events (25:00 - 28:00)

### Demo 7.1: SelectedIndex

```xml
<StackPanel>
    <TabControl x:Name="MyTabControl" Height="200">
        <TabItem Header="Tab 1">
            <TextBlock Text="Content 1" Margin="20"/>
        </TabItem>
        <TabItem Header="Tab 2">
            <TextBlock Text="Content 2" Margin="20"/>
        </TabItem>
        <TabItem Header="Tab 3">
            <TextBlock Text="Content 3" Margin="20"/>
        </TabItem>
    </TabControl>
    
    <StackPanel Orientation="Horizontal" 
                HorizontalAlignment="Center" 
                Margin="10">
        <Button Content="Tab 1" 
                Click="SelectTab1_Click" 
                Margin="5"/>
        <Button Content="Tab 2" 
                Click="SelectTab2_Click" 
                Margin="5"/>
        <Button Content="Tab 3" 
                Click="SelectTab3_Click" 
                Margin="5"/>
    </StackPanel>
</StackPanel>
```

**Code Behind:**
```csharp
private void SelectTab1_Click(object sender, RoutedEventArgs e)
{
    MyTabControl.SelectedIndex = 0;
}

private void SelectTab2_Click(object sender, RoutedEventArgs e)
{
    MyTabControl.SelectedIndex = 1;
}

private void SelectTab3_Click(object sender, RoutedEventArgs e)
{
    MyTabControl.SelectedIndex = 2;
}
```

### Demo 7.2: SelectionChanged Event

```xml
<TabControl SelectionChanged="TabControl_SelectionChanged">
    <TabItem Header="Home"/>
    <TabItem Header="Profile"/>
    <TabItem Header="Settings"/>
</TabControl>
```

**Code Behind:**
```csharp
private void TabControl_SelectionChanged(object sender, 
                                         SelectionChangedEventArgs e)
{
    if (e.Source is TabControl tabControl)
    {
        var selectedTab = tabControl.SelectedItem as TabItem;
        if (selectedTab != null)
        {
            MessageBox.Show($"Selected: {selectedTab.Header}");
        }
    }
}
```

---

## ส่วนที่ 8: Tips & Best Practices (28:00 - 31:00)

### 8.1 จำกัดจำนวน Tabs

```xml
<!-- ✅ ดี: 3-5 Tabs -->
<TabControl>
    <TabItem Header="Home"/>
    <TabItem Header="Profile"/>
    <TabItem Header="Settings"/>
</TabControl>

<!-- ⚠️ ระวัง: มากเกินไป -->
<TabControl>
    <!-- 15 Tabs - เยอะเกินไป! -->
</TabControl>
```

**แนะนำ:** ไม่เกิน 7 Tabs

### 8.2 ใช้ Icon และ Text

```xml
<!-- ✅ ดี: มี Icon ชัดเจน -->
<TabItem Header="🏠 Home"/>
<TabItem Header="👤 Profile"/>
<TabItem Header="⚙️ Settings"/>

<!-- ⚠️ ไม่ดี: Text เยอะเกินไป -->
<TabItem Header="This is a very long tab header that wraps"/>
```

### 8.3 ScrollViewer ใน Tab

```xml
<!-- ✅ ดี: มี ScrollViewer -->
<TabItem Header="Content">
    <ScrollViewer VerticalScrollBarVisibility="Auto">
        <StackPanel>
            <!-- Long content -->
        </StackPanel>
    </ScrollViewer>
</TabItem>
```

### 8.4 Default Selected Tab

```xml
<!-- ✅ ดี: กำหนด Tab เริ่มต้น -->
<TabControl SelectedIndex="0">
    <TabItem Header="Home"/>
    <TabItem Header="Profile"/>
</TabControl>
```

---

## ส่วนที่ 9: Wrap Up และ Outro (31:00 - 34:00)

**สรุปสิ่งที่เราได้เรียนรู้วันนี้:**

1. ✅ TabControl = Multi-page Interface
2. ✅ TabItem - แต่ละ Tab
3. ✅ Header - Custom ได้ (Icon, Badge, Rich Content)
4. ✅ Use Cases: Settings, Form, Dashboard
5. ✅ SelectedIndex - ควบคุม Tab ปัจจุบัน
6. ✅ SelectionChanged Event
7. ✅ Best Practices - จำกัดจำนวน Tabs

**TabControl เหมาะสำหรับ:**
- Settings Panel (ตั้งค่าหลายกลุ่ม)
- Multi-step Forms (แบบฟอร์มหลายขั้นตอน)
- Dashboard (หลายมุมมอง)
- Document Editor (หลายเอกสาร)
- Browser-like Apps (เหมือนเบราว์เซอร์)

**จุดเด่นของ TabControl:**
- ประหยัดพื้นที่หน้าจอ
- จัดระเบียบข้อมูล
- ง่ายต่อการนำทาง
- User-friendly

**สรุป Layout Series ทั้งหมด:**

เราได้เรียนรู้ Layout Panels ทั้งหมด 14 ตอน:
1. StackPanel - เรียงตามแนว
2. Grid - ตาราง
3. WrapPanel - ขึ้นบรรทัดใหม่อัตโนมัติ
4. DockPanel - Dock ขอบ
5. Canvas - ตำแหน่งแน่นอน
6. UniformGrid - Cell เท่ากันหมด
7. ScrollViewer - เลื่อนดูเนื้อหา
8. Border - กรอบและพื้นหลัง
9. Viewbox - ปรับขนาดอัตโนมัติ
10. Expander - ขยาย/ยุบ
11. GroupBox - จัดกลุ่ม
12. TabControl - Multi-page

**คุณพร้อมสร้าง WPF Application แล้ว!**

**อย่าลืม:**
- กด Like ถ้าชอบ
- Subscribe เพื่อติดตามตอนต่อไป
- Comment บอกว่าอยากเรียนเรื่องอะไรต่อไป

**ขอบคุณที่ติดตามซีรีส์นี้มาตลอดครับ!**

**แล้วพบกันใหม่ในซีรีส์ถัดไป สวัสดีครับ!**

---

## เอกสารอ้างอิง

### Official Documentation
- [TabControl Class - Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.tabcontrol)
- [TabItem Class - Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.tabitem)

### Properties Reference
```
TabControl Properties:
- SelectedIndex: Int32 (Tab ที่เลือก, 0-indexed)
- SelectedItem: Object (TabItem ที่เลือก)
- TabStripPlacement: Dock (ตำแหน่ง Tabs - Top, Bottom, Left, Right)

TabItem Properties:
- Header: Object (หัวข้อ Tab)
- Content: Object (เนื้อหาใน Tab)
- IsSelected: Boolean (ถูกเลือกหรือไม่)
```

### Events Reference
```csharp
SelectionChanged: SelectionChangedEventHandler (เมื่อเปลี่ยน Tab)
```

---

## TabStripPlacement

```xml
<!-- Tabs ด้านบน (Default) -->
<TabControl TabStripPlacement="Top">
    <!-- TabItems -->
</TabControl>

<!-- Tabs ด้านล่าง -->
<TabControl TabStripPlacement="Bottom">
    <!-- TabItems -->
</TabControl>

<!-- Tabs ด้านซ้าย -->
<TabControl TabStripPlacement="Left">
    <!-- TabItems -->
</TabControl>

<!-- Tabs ด้านขวา -->
<TabControl TabStripPlacement="Right">
    <!-- TabItems -->
</TabControl>
```

---

## Tips & Best Practices

1. **Limit Tabs**: ไม่เกิน 7 Tabs
2. **Clear Labels**: ใช้ชื่อ Tab ที่ชัดเจน
3. **Icons**: เพิ่ม Icon เพื่อความชัดเจน
4. **ScrollViewer**: ใส่ใน Tab ที่เนื้อหายาว
5. **Default Selection**: กำหนด SelectedIndex="0"

---

## Common Mistakes (ข้อผิดพลาดที่พบบ่อย)

### ❌ Tabs เยอะเกินไป
```xml
<!-- ผิด: 15 Tabs -->
<TabControl>
    <TabItem Header="Tab 1"/>
    <TabItem Header="Tab 2"/>
    <!-- ... 13 more tabs ... -->
</TabControl>
```

### ✅ ถูกต้อง
```xml
<TabControl>
    <TabItem Header="General"/>
    <TabItem Header="Advanced"/>
    <TabItem Header="About"/>
</TabControl>
```

### ❌ Header ไม่ชัดเจน
```xml
<!-- ผิด: ไม่รู้ว่ามีอะไร -->
<TabItem Header="Tab1"/>
<TabItem Header="Tab2"/>
```

### ✅ ถูกต้อง
```xml
<TabItem Header="🏠 Home"/>
<TabItem Header="👤 Profile"/>
```

### ❌ เนื้อหายาวไม่มี ScrollViewer
```xml
<!-- ผิด: เนื้อหาเกินจะไม่เห็น -->
<TabItem Header="Content">
    <StackPanel>
        <!-- Very long content -->
    </StackPanel>
</TabItem>
```

### ✅ ถูกต้อง
```xml
<TabItem Header="Content">
    <ScrollViewer VerticalScrollBarVisibility="Auto">
        <StackPanel>
            <!-- Very long content -->
        </StackPanel>
    </ScrollViewer>
</TabItem>
```

---

## Code Examples Repository

Source code สำหรับ Episode นี้สามารถดาวน์โหลดได้ที่:
- GitHub: [WPF_Episode14_TabControl](https://github.com/koson/WPF_Episode14_TabControl)

---

## 🎉 Series Complete!

**ขอบคุณที่ติดตามซีรีส์ WPF Layout Panels ทั้ง 14 ตอน!**

คุณได้เรียนรู้:
- ✅ StackPanel - เรียงตามแนว
- ✅ Grid - ตาราง Layout
- ✅ WrapPanel - ขึ้นบรรทัดใหม่
- ✅ DockPanel - Dock ขอบ
- ✅ Canvas - Absolute Positioning
- ✅ UniformGrid - Uniform Cells
- ✅ ScrollViewer - Scrolling
- ✅ Border - กรอบตกแต่ง
- ✅ Viewbox - Responsive Scaling
- ✅ Expander - Collapsible
- ✅ GroupBox - Grouping
- ✅ TabControl - Multi-page

**ตอนนี้คุณพร้อมสร้าง WPF Application ได้แล้ว!**

---

**End of Script**