   M S B A M L   `   `   `  ����O  KJailManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:JailManagementSystemJailManagementSystem  5   	   *    $JailManagementSystem.hearingschedule   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:JailManagementSystem     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#��[ 5   	    � Title$ hearingsched��5   	   $	��775��6   $
��1370��6+    � 
ResizeMode$ NoResize=�68    � WindowStartupLocation$ CenterScreen=�6N    � WindowStyle$
 None=�6s    � 	Resources 5       �� MergedDictionaries �� Source  menuopen	 �� TargetProperty
 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	menuclose�� 5   
    5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.PopupBox.xaml?�6%   %�  &	       &	 �     �� 5      .��5      U� $	 (FrameworkElement.Width)�60   $
 gridmenu��6e   .\�5        $ 0��6+   $ 0Q�67     5      $ 0:0:0.25��6+   $	 700Q�6>   5      5      �� 5      .��5      U� $	 (FrameworkElement.Width)�60   $
 gridmenu��6e   .\�5         $ 0��6+   $	 700Q�67     5!      $ 0:0:0.25��6+   $ 0Q�6>   5"      5#      5$      .��5(      �� .+�5)   
   �� -   5        $��
1315,5,5,0q�5)   '   $	��-20q�6;   ��6   Z� .��5*      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6&   5+      �� 5/   
   $
��Auto=�6   $��Hidden=�6:   .��50      �� -   5         ��Name$ panel_prisoner��50   2   $��20q�6   $
��1340��6%    �� Orientation$ Vertical=�6J   y�6a   ��  �� ElementName$ 
b_prisoner�� �� Path$ 	IsChecked�   BooleanToVisibilityConverter �� 	Converter# [ ��52      �� 53      .+�57      �  � ColumnDefinitions 58      �� 59      $��* �6+   �� 5:      $��* �6+   .+�5<      �� $��0��6    $��HEARING SCHEDULE��60   $
��Bold"�6H   $��35(�6Z   $��10,10,302,10q�6h   �� 5H      $��1��6    $��SEARCH:��60   $��150,30,275,0q�6?   $��20(�6U   �� 5I      -   5         ��Name$ tb_prisoner��5I      $��1��64   $��240,20,90,5q�6D   6Y   �� 5J      -   5        $��1��5J      $��
598,15,5,0q�6C   $
��Auto��6W   
������ .��5K        $ 	Camcorder=�62   $��40��6C   $��30��6N   5L      5M      � 5P       5Q      �� 5R      $��0* �6+   �� 5S      $
��281* �6+   .+�5W      &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid_hearing��5W       $��2��6�   $	��525��6�   $��20q�6�   5X      5Z      5[      5\      5`      5c      