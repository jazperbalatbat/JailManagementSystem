   M S B A M L   `   `   `  ����O  KJailManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:JailManagementSystemJailManagementSystem  5   	   #    JailManagementSystem.cellmain   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:JailManagementSystem     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5   
   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#��[ 5   	    � Title$ cellmain��5   	   $	��775��6   $
��1370��6'    � 
ResizeMode$ NoResize=�64    � WindowStartupLocation$ CenterScreen=�6J    � WindowStyle$
 None=�6o    � 	Resources 5       �� MergedDictionaries �� Source  menuopen	 �� TargetProperty
 �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	menuclose�� 5   
    5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.PopupBox.xaml?�6%   %�  &	       &	 �     �� 5      .��5      U� $	 (FrameworkElement.Width)�60   $
 gridmenu��6e   .\�5        $ 0��6+   $ 0Q�67     5      $ 0:0:0.25��6+   $	 700Q�6>   5      5      �� 5      .��5       U� $	 (FrameworkElement.Width)�60   $
 gridmenu��6e   .\�5!        $ 0��6+   $	 700Q�67     5"      $ 0:0:0.25��6+   $ 0Q�6>   5#      5$      5%      .��5(      �� .+�5)   
   �� -   5        $��
1315,5,5,0q�5)   '   $	��-20q�6;   ��6   Z� .��5*      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6&   5+      �� 5/   
   $
��Auto=�6   $��Hidden=�6:   .��50      �� -   5         ��Name$ panel_prisoner��50   2   $��20q�6   $
��1340��6%    �� Orientation$ Vertical=�6J   y�6a   ��  �� ElementName$ 
b_prisoner�� �� Path$ 	IsChecked�   BooleanToVisibilityConverter �� 	Converter# [ ��52      �� 53      .+�57      �  � ColumnDefinitions 58      �� 59      $��* �6+   �� 5:      $��* �6+   .+�5<      �� $��0��6    $��CELL STATUS��60   $
��Bold"�6C   $��35(�6U   $��10,10,45,10q�6c   5J      � 5N       5O      �� 5P      $��0* �6+   �� 5Q      $
��281* �6+   .+�5U      &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid_cell��5U       $��2��6�   $	��525��6�   $��20q�6�   5V      � 5Y      -   5         �Name$
 edit��5Y      $	��525��6)   $��20q�66   $��2��6B   
������ $y�Hidden=�6o   .+�5Z      �� $
��Auto=�6'   $
��Auto=�6J   .��5[      #  MaterialDesignThemes.Wpf.Card  $��40q�62   $��0q�6?   .��5\   "   �� -   5        $ update_panel��5\   -   ��5]   &   �� 5^   *   .+�5a   &   �� $��0��60   $��UPDATE CELL��6@   $
��Bold"�6S   $��35(�6e   $��0 0 0 0q�6s   �� 5c   &   $��0 00 0 0q�61   .+�5d   *   �� $ 
Horizontal=�65   5e   +   � 5h   *    5i   .   �� 5j   2   $��* �6C   �� 5k   2   $��* �6C   �� 5l   2   $��* �6C   �� 5m   2   $��* �6C   .+�5o   .   �� $��0��68   $��ID��6H   $��
5,10,108,5q�6R   �� 5p   .   -   5         ��Name$ id��5p   6   $��1��6B   $��5 5 5 5q�6R   �� 5q   .   $��2��68   $��CELL NUMBER��6H   $��35,21,275,-11q�6[   $��2��6r   �� 5r   .   -   5         ��Name$ cellnum��5r   7   $��
262,5,46,5q�6H   $��2��6\   $��2��6l   .@�5s   2   �� .��6?   CELL 16G   �� 5t   2   .��6?   CELL 26G   �� 5u   2   .��6?   CELL 36G   �� 5v   2   .��6?   CELL 46G   �� 5w   2   .��6?   CELL 56G   5x   /   5y   +   � 5}   *    5~   .   �� 5   2   $��* �6C   �� 5�   2   $��* �6C   5�   +   � 5�   *    5�   .   �� 5�   2   $��* �6C   �� 5�   2   $��* �6C   �� 5�   2   $��* �6C   �� 5�   2   $��* �6C   .+�5�   .   �� $��0��68   $��DESCRIPTION��6H   $��5,5,18,5q�6[   �� 5�   .   -	   5        $ description��5�   6   $��1��6K   $��5 5 5 5q�6[   �� 5�   .   $��2��68   $��NUMBER OF INMATES��6H   $��
35,5,211,5q�6a   $��2��6u   �� 5�   .   -
   5        $ num_inmates��5�   6   $��2��6K   $��270,10,45,0q�6[   $��2��6p   5�   +   � 5�   *    5�   .   �� 5�   2   $��* �6C   �� 5�   2   $��* �6C   �� 5�   2   $��* �6C   �� 5�   2   $��* �6C   .+�5�   .   �� $��0��68   $��STATUS��6H   $��5,5,18,5q�6V   �� 5�   .   -   5        $ status��5�   6   $��1��6F   $��5 5 5 5q�6V   .��6g   5�   /   5�   +   � 5�   *   $��0 0 0 0q�6/   .+�5�   .   �� -   5         ��Name$ update_cell��5�   5   $��0��6J   $	��200��6Z   $��	530 0 0 0q�6f   $��UPDATE��6y   $��15(�6�   $
��Bold"�6�   
�������6�   �� 5�   .   -   5        $ add_cancel_cell��5�   5   $��1��6N   $	��200��6^   $��	980 0 0 0q�6j   $��CANCEL��6}   $��15(�6�   $
��Bold"�6�   
�������6�   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      