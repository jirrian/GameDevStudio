//Maya ASCII 2016 scene
//Name: ramp.ma
//Last modified: Sat, Jul 18, 2015 09:04:46 PM
//Codeset: 1252
requires maya "2016";
requires "stereoCamera" "10.0";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2016";
fileInfo "version" "2016";
fileInfo "cutIdentifier" "201502261600-953408";
fileInfo "osv" "Microsoft Windows 7 Home Premium Edition, 64-bit Windows 7 Service Pack 1 (Build 7601)\n";
fileInfo "license" "student";
createNode transform -n "pCube1";
	rename -uid "CB7C3A93-4C5A-1BCE-9E7C-859D03BC54AB";
	setAttr ".t" -type "double3" -0.50091197302574741 1.0469261274541939 3.4784614179733948 ;
createNode mesh -n "pCubeShape1" -p "pCube1";
	rename -uid "39BF30C6-4F84-6B3C-07DE-3784F70D89E0";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.625 0.875 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 17 ".uvst[0].uvsp[0:16]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.125 0
		 0.125 0.25 0.43851858 0.25 0.43851858 0.5 0.43851858 0.75 0.43851858 0 0.43851858
		 1;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 12 ".vt[0:11]"  -3.45545959 -1.046926141 1.46118855 3.45545959 -1.046926141 1.46118855
		 -3.45545959 1.046926141 1.46118855 5.50966454 -1.046926141 1.46118855 -3.45545959 1.046926141 -1.46118855
		 5.50966454 -1.046926141 -1.46118855 -3.45545959 -1.046926141 -1.46118855 3.45545959 -1.046926141 -1.46118855
		 -1.69957292 1.046926141 1.46118855 -1.69957292 1.046926141 -1.46118855 -1.69957292 -1.046926141 -1.46118855
		 -1.69957292 -1.046926141 1.46118855;
	setAttr -s 19 ".ed[0:18]"  0 11 0 2 8 0 4 9 0 6 10 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 8 3 0 9 5 0 8 9 1 10 7 0 9 10 1 11 1 0 10 11 1 11 8 1;
	setAttr -s 9 -ch 38 ".fc[0:8]" -type "polyFaces" 
		f 4 0 18 -2 -5
		mu 0 4 0 15 12 2
		f 4 1 13 -3 -7
		mu 0 4 2 12 13 4
		f 4 2 15 -4 -9
		mu 0 4 4 13 14 6
		f 4 3 17 -1 -11
		mu 0 4 6 14 16 8
		f 4 10 4 6 8
		mu 0 4 10 0 2 11
		f 4 11 7 -13 -14
		mu 0 4 12 3 5 13
		f 4 -16 12 9 -15
		mu 0 4 14 13 5 7
		f 6 -17 -18 14 -10 -8 -6
		mu 0 6 9 16 14 7 5 3
		f 4 -19 16 5 -12
		mu 0 4 12 15 1 3;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".db" yes;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 4 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :defaultColorMgtGlobals;
	setAttr ".cme" no;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "pCubeShape1.iog" ":initialShadingGroup.dsm" -na;
// End of ramp.ma
