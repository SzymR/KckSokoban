   M S B A M L   `   `   `  ����  KckSokoban WPF    KckSokoban_WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  
MainWindow��5   	   $	��500��6   $	��500��6)    � WindowStartupLocation$ CenterScreen=�65   .��5      � .+�5   
   �� $	��450��6   $	��450��6!   
���   �6-   � 5   
   -   5        $
��grid��5      $	��450��6   $	��450��6(    J� SnapsToDevicePixels . 64   � 5	   
   -   5        $��gridMenuMain��5	      $	��450��6#   $	��450��60    .  � RowDefinitions 5
      �� 5      $��* �6    �� 5      $
��0.9* �6    .+�5      � -   5        $��header��5      .+�5      �� -   5        $��myrect��5   .   $��0,18,0,0q�6   $	��150��6<   $	��150��6H   ��5      �� 5       �� ImageSource$ Image/b.png��6%    j� Stretch$ Uniform=�6?    � Triggers 5      :� 5       :� RoutedEvent$ Window.Loaded��6'   .[�5      �� .��5   "   ��  g� RepeatBehavior$ Forever��6-   .��5   &   W� 	 �� 
TargetName$	 myrect��66   
 �� TargetProperty$
 Width�5        W� From$	 150X�6:   	 W� To$	 350X�6E    g� Duration$ 0:0:1D�5!       g� 	BeginTime$ 0:0:0X�6)    g� AutoReverse . 6;   W� 5"   &   $	 myrect��66   $
 Height�5#      $	 150X�6;   $	 250X�6F   $ 0:0:1D�5$      $ 0:0:1X�6)    . 6;   5-   #   5.      5/      51      5J      � 5K      -   5        $��gridMenu��5K       $��1��6   $��2q�61   $	��450��6<    . 5M      � 5N      -   5        $��gridMenuChooseLevel��5N       $��1��6   $��2q�6<   $	��450��6G    . 5P      �� 5Q      -   5        $
��Head��5Q      5R      5S      5T      