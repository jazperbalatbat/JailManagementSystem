   M S B A M L   `   `   `  ����O  KJailManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:JailManagementSystemJailManagementSystem  5   	   ,    &JailManagementSystem.prisonerfacerecog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:JailManagementSystem     5   	   V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#��[ 5   	    � Title$ prisonerfacerecog��5   	   $	��450��6#   $	��800��60   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��349* �6   �� 5      $	��47* �6   .+�5   
   �� -   5         ��Name$ face_preview��5      $
��Left=�6&   $	��399��6A   $��	10,10,0,0q�6N   $	��Top=�6a   $	��409��6y   �� 5   
   -   5         ��Name$ deten_recog��5      $+��%Detect and Recognize                 ��6&   $
��Left=�5      $��
424,10,0,0q�6.   $	��Top=�6B   $	��122��6Z   $��29��6f   6r   �� 5   
   -   5         ��Name$ 
face_count��5      $��0��6$   $
��Left=�60   $��
551,10,0,0q�6K   $	��Top=�6_   $	��137��6w   �� 5   
   -   5         ��Name$ face_persons��5      $��nobody��6*   $
��Left=�68   $��
551,41,0,0q�6S   $	��Top=�6g   $	��137��6   �� 5   
   -   5        $ face_add��5      $��Add Face            ��6#   $
��Left=�6B   $��424,240,0,0q�6]   $	��Top=�6r   $	��122��6�   $��29��6�   6�   �� 5   
   -   5         ��Name$ person_name��5      $
��Left=�6'   $��23��6B   $��426,202,0,0q�6N   	 �� TextWrapping$
	 Wrap=�6c   $
��name��6w   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ train_image��5      $
��Left=�6%   $	��120��6@   $��
426,67,0,0q�6M   $	��Top=�6a   $	��120��6y   �� 5    
   -	   5        $ train_detect��5    ,   $
��Left=�6B   $��426,287,0,0q�6^   $	��Top=�6s   $��	Find Face��6�   $	��122��6�   $��29��6�   5!      5"      