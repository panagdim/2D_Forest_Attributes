# 2D_Forest_Attributes

About

2D_Forest_Attributes is a windows form application which can be used to visualize:
a) tree positions (measured in local and global coordinate system) and
b) tree crowns; measured in the field using 8 radii per tree

It also calcualates the tree basal area (based on the given DBH)

The input data (.txt) should follow the below structure:
# x | y | * Azimuth | * Dist 1 | Dist 2 | Dist 3| Dist 4 | Dist 5 | Dist 6 | Dist 7 | Dist 8 | * DBH | 

* Dist 1,2,3, etc: refers to the horizontal distance of each point from the stem
* Azimuth in rad.
* DBH in cm

The txt file should be placed inside your bin folder of your project.
An illustration of the structure can be seen in the attached figure.
There is an additional option to export the 2D graph if image format.

Contributors: Dimitrios Panagiotidis

