   M S B A M L   `   `   `  ����B  >Wpf2048, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:Wpf2048Wpf2048  5   	       Wpf2048.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Wpf2048     5   	   -   5          � Title$  Игра 2048��5   	   $	��450��6   $	��450��6(    � 	Resources 5
         TileTemplate �� 
TargetType �� RadiusX �� RadiusY  
TilesStyle �� Property �� Value �� Color �� Triggers	 P� Property
 P� Value��%�  &	        &	 �     7   �� 5   
   " ��6/   .R�5      � .+�5      �� $ 10��6   $ 10��6)   #��z��66   #��z��6Z   �� 5      $��Center=�6#   $��Center=�6@   5      5      �� 5   
   �5      �� 5       � ��8   63   �� 5       � ��$ 30(�63   �� 5       � ��$ Stretch=�6>   �� 5       � ��$ Stretch=�6<   �� 5       � ��$ Center=�6E   �� 5       � ��$ Center=�6C   �� 5       � �� 5      �� 5      $ Cornsilk��6*   5       5      P� 5       	 � ��$
  ��63   . �5!      ��  � �� 5"      �� 5#      $ 	LightGray��6.   5%      5&      5(      5*      .��5,      �  � RowDefinitions 5-   
   �� 5.      $��25 �6   �� 5/      .+�51   
   � $��0��6   .+�52      �� -   5        .��52   1   Новая игра6=   53      � 54   
   -   5         �Name$ 	FieldView��54   2   $��1��6   
�������56      57      58      