   M S B A M L   `   `   `  ����O  KJailManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:JailManagementSystemJailManagementSystem  5   	   g cMicrosoft.ReportViewer.WinForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91tSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinFormsMicrosoft.Reporting.WinForms 5   	   (    "JailManagementSystem.inmatereports   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:JailManagementSystem     5   	   brvSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinForms     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5
   
   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#��[ 5   	    � Title$ casemain��5   	   $	��775��6   $
��1370��6'    � 
ResizeMode$ NoResize=�64    � WindowStartupLocation$ CenterScreen=�6J    � WindowStyle$
 None=�6o    � 	Resources 5       �� MergedDictionaries �� Source  menuopen	 �� TargetProperty
 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	menuclose�� 5   
    5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.PopupBox.xaml?�6%   %�  &	       &	 �     �� 5      .��5       U� $	 (FrameworkElement.Width)�60   $
 gridmenu��6e   .\�5!        $ 0��6+   $ 0Q�67     5"      $ 0:0:0.25��6+   $	 700Q�6>   5#      5$      �� 5%      .��5&      U� $	 (FrameworkElement.Width)�60   $
 gridmenu��6e   .\�5'        $ 0��6+   $	 700Q�67     5(      $ 0:0:0.25��6+   $ 0Q�6>   5)      5*      5+      .��5-      �� .+�5.   
   �� -   5        $��
1315,5,5,0q�5.   '   $	��-20q�6;   ��6   Z� .��5/      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6&   50      �� 53   
   $
��Auto=�6   $��Hidden=�6:   $	��224��6a   .��54      �� -   5         ��Name$ panel_prisoner��54   2   $��20q�6   $
��1340��6%    �� Orientation$ Vertical=�6J   y�6a   ��  �� ElementName$ 
b_prisoner�� �� Path$ 	IsChecked�   BooleanToVisibilityConverter �� 	Converter# [ .+�55      �  � ColumnDefinitions 56      �� 57      $��* �6+   �� 58      $��* �6+   .+�5:      �� $��0��6    $��PRISONER REPORTS��60   $
��Bold"�6H   $��35(�6Z   $��10,0,188,20q�6h   5;      � 5=       5>      �� 5?      $��* �6+   �� 5@      $��* �6+   .+�5C      �� $��DemiBold"�6    $��0��66   $��CHOOSE REPORT��6F   $��2��6[   $��30,10,640,-10q�6o   �� 5D      $��
154,0,10,0q�6   .@�5E      �� -   5        $��SUMMARY REPORT��5E   H   �� 5F      -   5        $��INDIVIDUAL REPORT��5F   J   5G      5H      � 5I      -   5         �Name$ search��5I      $y�Hidden=�6'    5J      �� 5K      $	��76* �6+   �� 5L      $
��371* �6+   �� 5M      $
��446* �6+   �� 5N      $
��447* �6+   .+�5Q      �� $��DemiBold"�6    $��0��66   $��SEARCH��6F   $��2��6T   $��33,20,191,-20q�6h   �� 5R      -   5         ��Name$ searchp��5R      $��2��6/   $��76,10,235,-10q�6C   $��1��6Z   �� 5S      -   5        $
��SHOW��5S   2   $��2��6A   $��2��6U   $��353,10,207,-10q�6e   5T      � 5U      -   5        $
 date��5U      $y�Hidden=�6%    5V      �� 5W      $
��134* �6+   �� 5X      $
��134* �6+   �� 5Y      $
��134* �6+   �� 5Z      $	��34* �6+   �� 5[      $	��79* �6+   �� 5\      $	��21* �6+   �� 5]      $
��134* �6+   .+�5`      �� $��DemiBold"�6    $��0��66   $
��FROM��6F   $��3��6R   $��30,30,238,-30q�6f   (  "System.Windows.Controls.DatePicker  5a      -	   5          Name$
 from��5a   !   $��151,21,189,-21q�6/   $��2��6G   �� 5b      $��DemiBold"�6    $��TO��66   $��112,29,132,-29q�6@   $��1��6X     5c      -
   5        $ to��5c   !   $��2��6-   $��174,21,144,-21q�6A   $��1��6Y   �� 5d      -   5        $
��SHOW��5d   4   $��4��6C   $��3��6W   $��0,32,208,-32q�6g   5e      5g      5h      7  1System.Windows.Forms.Integration.WindowsFormsHost  5i   
   -   5        $
��Left=�5i      $	��516��66   $
��1365��6C      Child. 5j      /  )Microsoft.Reporting.WinForms.ReportViewer  -   5        inmateReportViewer��5j      5k      5o      5p      