   M S B A M L   `   `   `  ����O  KJailManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:JailManagementSystemJailManagementSystem  5   	   $    JailManagementSystem.addescort   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:JailManagementSystem     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5           MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#��[ 5   	    � Title$ 	escortadd��5   	   $	��450��6   $
��1000��6(    � 
ResizeMode$ NoResize=�65    � WindowStyle$
 None=�6K    � WindowStartupLocation$ CenterScreen=�6^   .��5      #  MaterialDesignThemes.Wpf.Card  +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�6   .��5   
   �� .+�5      �� -   5        $��950,5,0,-15q�5   +   $	��-20q�6@   $��42��6e   ��6   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6*   5        5      $��5q�6"   $��20q�6.   .��5      �� $
��Auto=�6   $��Hidden=�6B   .��5      �� $��10q�6!   .+�5      �� $��0��6$   $��
ADD ESCORT��64   $
��Bold"�6F   $��35(�6X   �� 5        �� Orientation$ 
Horizontal=�6%   .+�5!      �� $��images/policeescort.png��6$   $��90��6E   $��10 0 0 0q�6Q   5(      � 5+      	 � ColumnDefinitions	 5,      �� 5-   "   $��* �63   �� 5.   "   $��* �63   �� 5/   "   $��* �63   �� 50   "   $��* �63   .+�52      �� $��0��6(   $��ID��68   $��	5,5,108,5q�6B   �� 53      -   5        
 ��Name$
 id��53   2   $	��300��6&   $��112,5,214,5q�6>   {�.  $��2��6e   54      � 58      	 59      �� 5:   "   $	��45* �63   �� 5;   "   $
��187* �63   �� 5<   "   $
��234* �63   �� 5=   "   $	��50* �63   �� 5>   "   $
��181* �63   �� 5?   "   $
��233* �63   .+�5A      �� $��0��6(   $��
FIRST NAME��68   $��5,5,18,5q�6J   $��2��6\   �� 5B      -   5        $
 	firstname��5B   2   $	��300��6&   $��1��6E   $��101,10,166,0q�6U   $��2��6k   �� 5C      $��2��6(   $��	LAST NAME��68   $��176.5,5,117,5q�6I   $��3��6`   �� 5D      -   5        $
 lastname��5D   2   $	��300��6&   $��4��6D   $��
0,0,212,10q�6T   $��2��6h   5E      � 5I      	 5J      �� 5K   "   $��* �63   �� 5L   "   $��* �63   .+�5P      �� $��0��6(   $��Position��68   $��5 5 5 5q�6H   �� 5Q      -   5        $
 position��5Q   2   $	��300��6&   $��96,0,134,10q�6D   5R      � 5X      $��10q�6   .+�5\      �� `� 5]      .�5^   "   c�   MaterialDesignToolBar#���  6*   .@�5_   &   �� $��INMATE TO ESCORT��60   $��0 0 20 0q�6H   $��Center=�6Z   $��17(�6u   $
��Bold"�6�   '  !MaterialDesignThemes.Wpf.PopupBox  5`   &   $��58��6>    � ToolTip$ inmate to visit��6J      ToggleContent 5a   *     5b   .   $ AccountPlus=�6F   $��40��6Y   $��29��6d   
�������6p      PopupContent. 5d   *   �� .+�5e   .   � 	 5f   2   �� 5g   6   $��* �6G   �� 5h   6   $��* �6G   .+�5j   2   �� $��	30 10 0 0q�6<   $��0��6O   $��SEARCH: ��6_   �� 5k   2   $��1��6:   $��90��6J   5l   /   �� 5m   .   $
��Auto=�6;   $
��Auto=�6^   .��5n   2   &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid_escort��5n   ;   $��3��6T   $	��525��6h   $��20q�6u   5p   3   5q   /   5r   +   5s   '   �� 5t   &   $ 
Horizontal=�61   $��Center=�6J   $��Center=�6e   .+�5u   *   �� -   5         ��Name$
 p_id��5u   4   $y�Hidden=�6B   $��0 0 5 0q�6V   �� 5v   *   -	   5        $ 
p_lastname��5v   4   $y�Hidden=�6H   $��0 0 5 0q�6\   �� 5w   *   -
   5        $ p_firstname��5w   4   $y�Hidden=�6I   $��0 0 5 0q�6]   �� 5x   *   -   5        $ p_middlename��5x   4   $y�Hidden=�6J   �� 5y   *   -   5        $ p_hearingdate��5y   4   $y�Hidden=�6K   �� 5z   *   -   5        $ p_hearingtime��5z   4   $y�Hidden=�6K   5{   '   � 5~   &   $��20q�6+   	 5   *   �� 5�   .   $��4* �6?   �� 5�   .   $��1* �6?   .+�5�   *   �� -   5        $	��250��5�   1   $��0��6=   $	��ADD��6M   $��15(�6[   $
��Bold"�6i   $��103,0,417,0q�6{   6�   �� 5�   *   -   5        $	��250��5�   2   $��CANCEL��6>   $��15(�6P   $
��Bold"�6^   $	��Top=�6�   $��380,0,140,0q�6�   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      