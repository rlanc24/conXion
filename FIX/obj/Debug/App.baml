   M S B A M L   `   `   `  ����B  >conXion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:FIXFIX  5          FIX.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      #localclr-namespace:FIX     5        �� 	Resources  5         FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1 �� 
TargetType �� 
TargetType ��Name  ButtonStyle2	 ��Name  ProgressBar.Progress  ProgressBar.Background  ProgressBar.Border  ProgressBarStyle1
 �Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� RepeatBehavior �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value8  2System.Windows.Media.Animation.EasingPointKeyFrame $� KeyTime $� Value ��Name J� RenderTransformOrigin �� Triggers P� Property P� Value �� 
TargetName �� Angle  TextBox.Static.Border  TextBox.MouseOver.Border  TextBox.Focus.Border  TextBoxStyle1-  'System.Windows.Input.KeyboardNavigation ��Name �� Triggers ]� 
Conditions �� Property  �� Value��%6  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  &	 �    7   7  7  &	 3    &	 V    &	 y    &	 �    7  7  7  &	 /    &	 R    &	 u    &	 �    7  �� 5   
   .�5	      ��  � �� 5
      �� 5      .R�5      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5       � ��# � ��6+   �� 5       � ��$ 1q�60   �� 5        � ��$ Center=�6;   �� 5!       � ��$ Center=�69   �� 5"       � ��$ 1q�6(   �� 5#       � �� 5$      �� 5%      " ��6&   .R�5&      �� $ border��6!   #��z��61   $��0q�6]   #��z��6q    . 5'      5(      5*      5+      �� 5,   
   " ��6%   .�5-      ��  �@�FocusVisualStyle8   61   �� 5.       � ��8  6+   �� 5/       � ��8  6,   �� 50       � ��# � ��6+   �� 51       � ��$ 1q�60   �� 52       � ��$ Center=�6;   �� 53       � ��$ Center=�69   �� 54       � ��$ 1q�6(   �� 55       � �� 56      �� 57      " ��6&   .R�58      �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . ._�59      �� $	 contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5:      5;      5=      5>      �� 5?   
   $ 	#FF06B025��67   �� 5@   
   $ 	#FFE6E6E6��69   �� 5A   
   $ 	#FFE6E6E6��65   �� 5B   
   " �6*   .�5C      ��  � ��8   6+   �� 5D       � ��8  6+   �� 5E       � ��8  6,   �� 5F       � ��$ 0q�60   �� 5G       � �� 5H      �� 5I      " �6&   .R�5J      � $
 TemplateRoot��6    5K        5L   "   CommonStates��. 5M   &     Determinate��62     5N   &   Indeterminate��. 5O   *   �� $ Forever��65   .��5P   .   U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6L   $ 	Animation��6�   .\�5Q   2     $ 0��6G   $
 0.25Q�6S     5R   2   $ 0:0:1��6G   $
 0.25Q�6W     5S   2   $ 0:0:2��6G   $
 0.25Q�6W   5T   /   *� 5U   .   $' !(UIElement.RenderTransformOrigin)�6K   $ 	Animation��6�   .'�5V   2     $ 0��6F   $ -0.5,0.5&�6R     5W   2   $ 0:0:1��6F   $ 0.5,0.5&�6V     5X   2   $ 0:0:2��6F   $ 1.5,0.5&�6V   5Y   /   5Z   +   5[   '   5\   #   .+�5^      �� #��z��6%   #��z��6Q   #��z��6�   �� 5_      $ 
PART_Track��6(   � 5`      $
 PART_Indicator��6#   }�. $
��Left=�6O   .+�5a   "   �� $ 	Indicator��6,   #��z��6?   �� 5b   "   $ 	Animation��6,   #��z��6?   $ 0.5,0.5&�6c   z�5c   &   V� 5d   *   .~�5e   .   �� �� 5f   .   �� 5g   .   T� 5h   .   5i   +   5k   #   5l      5m       5n      P� 5o       �@�Orientation$ Vertical=�6=   . �5p   "   �� $ TemplateRoot��6D    �@�LayoutTransform 5q   &   �� 5r   *   $	 -90Q�6:   5t   #   5u      P� 5v       �@�IsIndeterminate . . �5w   "   �� $ 	Indicator��6?    � y�$ 	Collapsed=�6V   5x      5z      5|      5}      �� 5~   
   $ 	#FFABAdB3��68   �� 5   
   $ 	#FF7EB4EA��6;   �� 5�   
   $ 	#FF569DE5��67   �� 5�   
   " ��6&   .�5�      ��  � ��# � ��6+   �� 5�       � ��8   6,   �� 5�       � ��# � ��6+   �� 5�       � ��$ 1q�60   �� 5�       �@ TabNavigation$
 None=�6A   �� 5�       � ��$
 Left=�6;   �� 5�       �@�FocusVisualStyle 61   Z� �� 5�       �@J�	AllowDrop . 6*   �� 5�       �@��PanningMode$ VerticalFirst=�69   �� 5�       �@��IsFlicksEnabled .  67   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . ._�5�      �� $ PART_ContentHost��6+   |�.  $��Hidden=�6W   $��Hidden=�6~   5�      5�      5�       5�      ]� 5�       5�      �� 5�      + �@��#IsInactiveSelectionHighlightEnabled  . 6S   �� 5�       �@��IsSelectionActive  .  6A   ./�5�      ��  �@��SelectionBrush# � /�67   5�      5�      5�      5�      