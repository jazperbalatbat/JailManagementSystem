   M S B A M L   `   `   `  ����O  KJailManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:JailManagementSystem.reportsJailManagementSystem.reports  5   	   g cMicrosoft.ReportViewer.WinForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91tSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinFormsMicrosoft.Reporting.WinForms 5   	   0    *JailManagementSystem.reports.officerreport   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:JailManagementSystem.reports     5   	   brvSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinForms     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#��[ 5   	    � Title$ officerreports��5   	   $	��775��6    $
��1370��6-    � 
ResizeMode$ NoResize=�6:    � WindowStartupLocation$ CenterScreen=�6P    � WindowStyle$
 None=�6u    � 	Resources 5       �� MergedDictionaries �� Source  menuopen	 �� TargetProperty
 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	menuclose�� 5   
    5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.PopupBox.xaml?�6%   %�  &	       &	 �     �� 5      .��5      U� $	 (FrameworkElement.Width)�60   $
 gridmenu��6e   .\�5        $ 0��6+   $ 0Q�67     5      $ 0:0:0.25��6+   $	 700Q�6>   5      5      �� 5      .��5      U� $	 (FrameworkElement.Width)�60   $
 gridmenu��6e   .\�5         $ 0��6+   $	 700Q�67     5!      $ 0:0:0.25��6+   $ 0Q�6>   5"      5#      5$      .��5&      �� .+�5'   
   �� -   5        $��
1315,5,0,0q�5'   '   $	��-20q�6;   $
��Left=�6`   $��50��6{   ��6   Z� .��5(      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6&   5)      �� 5,   
   $
��Auto=�6   $��Hidden=�6:   $	��224��6a   .��5-      �� -   5         ��Name$ panel_prisoner��5-   2   $��20q�6   $
��1340��6%    �� Orientation$ Vertical=�6J   y�6a   ��  �� ElementName$ 
b_prisoner�� �� Path$ 	IsChecked�   BooleanToVisibilityConverter �� 	Converter# [ .+�5.      �  � ColumnDefinitions 5/      �� 50      $��* �6+   �� 51      $��* �6+   .+�53      �� $��0��6    $��JAIL OFFICER REPORTS��60   $
��Bold"�6L   $��35(�6^   $��10,0,148,20q�6l   54      � 55      -   5         �Name$
 date��55      $y�Visible=�6%    56      �� 57      $
��134* �6+   �� 58      $
��134* �6+   �� 59      $
��134* �6+   �� 5:      $	��34* �6+   �� 5;      $	��79* �6+   �� 5<      $	��21* �6+   �� 5=      $
��134* �6+   .+�5@      �� $��DemiBold"�6    $��0��66   $
��FROM��6F   $��3��6R   $��30,30,238,-30q�6f   (  "System.Windows.Controls.DatePicker  5A      -   5          Name$
 from��5A   !   $��151,21,189,-21q�6/   $��2��6G   �� 5B      $��DemiBold"�6    $��TO��66   $��112,29,132,-29q�6@   $��1��6X     5C      -   5        $ to��5C   !   $��2��6-   $��174,21,144,-21q�6A   $��1��6Y   �� 5D      -   5        $
��SHOW��5D   4   $��4��6C   $��3��6W   $��0,32,208,-32q�6g   5E      5G      5H      7  1System.Windows.Forms.Integration.WindowsFormsHost  5I   
   -   5        $
��Left=�5I      $	��516��66   $
��1365��6C      Child. 5J      /  )Microsoft.Reporting.WinForms.ReportViewer  -   5        officerReportViewer��5J      5K      5N      5O      