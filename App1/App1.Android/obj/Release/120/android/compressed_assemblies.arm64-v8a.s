	.arch	armv8-a
	.file	"compressed_assemblies.arm64-v8a.arm64-v8a.s"
	.include	"compressed_assemblies.arm64-v8a-data.inc"

	.section	.data.compressed_assembly_descriptors,"aw",@progbits
	.type	.L.compressed_assembly_descriptors, @object
	.p2align	3
.L.compressed_assembly_descriptors:
	/* 0: App1.Android.dll */
	/* uncompressed_file_size */
	.word	542720
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_0

	/* 1: App1.dll */
	/* uncompressed_file_size */
	.word	870400
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_1

	/* 2: FormsViewGroup.dll */
	/* uncompressed_file_size */
	.word	15872
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_2

	/* 3: Java.Interop.dll */
	/* uncompressed_file_size */
	.word	164864
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_3

	/* 4: Microsoft.Bcl.AsyncInterfaces.dll */
	/* uncompressed_file_size */
	.word	6144
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_4

	/* 5: Mono.Android.dll */
	/* uncompressed_file_size */
	.word	2192896
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_5

	/* 6: Mono.Cecil.Mdb.dll */
	/* uncompressed_file_size */
	.word	38912
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_6

	/* 7: Mono.Cecil.Pdb.dll */
	/* uncompressed_file_size */
	.word	88576
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_7

	/* 8: Mono.Cecil.Rocks.dll */
	/* uncompressed_file_size */
	.word	24576
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_8

	/* 9: Mono.Cecil.dll */
	/* uncompressed_file_size */
	.word	355328
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_9

	/* 10: Mono.Security.dll */
	/* uncompressed_file_size */
	.word	122880
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_10

	/* 11: Newtonsoft.Json.dll */
	/* uncompressed_file_size */
	.word	684544
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_11

	/* 12: System.Buffers.dll */
	/* uncompressed_file_size */
	.word	13704
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_12

	/* 13: System.Core.dll */
	/* uncompressed_file_size */
	.word	391168
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_13

	/* 14: System.Data.dll */
	/* uncompressed_file_size */
	.word	748032
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_14

	/* 15: System.Drawing.Common.dll */
	/* uncompressed_file_size */
	.word	26112
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_15

	/* 16: System.Net.Http.dll */
	/* uncompressed_file_size */
	.word	218112
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_16

	/* 17: System.Numerics.dll */
	/* uncompressed_file_size */
	.word	38912
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_17

	/* 18: System.Runtime.CompilerServices.Unsafe.dll */
	/* uncompressed_file_size */
	.word	8192
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_18

	/* 19: System.Runtime.Serialization.dll */
	/* uncompressed_file_size */
	.word	419328
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_19

	/* 20: System.ServiceModel.Internals.dll */
	/* uncompressed_file_size */
	.word	55808
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_20

	/* 21: System.Text.Encodings.Web.dll */
	/* uncompressed_file_size */
	.word	67072
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_21

	/* 22: System.Text.Json.dll */
	/* uncompressed_file_size */
	.word	497152
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_22

	/* 23: System.Threading.Tasks.Extensions.dll */
	/* uncompressed_file_size */
	.word	14224
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_23

	/* 24: System.Xml.Linq.dll */
	/* uncompressed_file_size */
	.word	65024
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_24

	/* 25: System.Xml.dll */
	/* uncompressed_file_size */
	.word	1397760
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_25

	/* 26: System.dll */
	/* uncompressed_file_size */
	.word	878592
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_26

	/* 27: Xamarin.AndroidX.Activity.dll */
	/* uncompressed_file_size */
	.word	53248
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_27

	/* 28: Xamarin.AndroidX.AppCompat.AppCompatResources.dll */
	/* uncompressed_file_size */
	.word	16896
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_28

	/* 29: Xamarin.AndroidX.AppCompat.dll */
	/* uncompressed_file_size */
	.word	463360
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_29

	/* 30: Xamarin.AndroidX.Browser.dll */
	/* uncompressed_file_size */
	.word	30720
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_30

	/* 31: Xamarin.AndroidX.CardView.dll */
	/* uncompressed_file_size */
	.word	17920
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_31

	/* 32: Xamarin.AndroidX.CoordinatorLayout.dll */
	/* uncompressed_file_size */
	.word	79360
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_32

	/* 33: Xamarin.AndroidX.Core.dll */
	/* uncompressed_file_size */
	.word	596480
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_33

	/* 34: Xamarin.AndroidX.CustomView.dll */
	/* uncompressed_file_size */
	.word	9216
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_34

	/* 35: Xamarin.AndroidX.DrawerLayout.dll */
	/* uncompressed_file_size */
	.word	44032
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_35

	/* 36: Xamarin.AndroidX.Fragment.dll */
	/* uncompressed_file_size */
	.word	175104
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_36

	/* 37: Xamarin.AndroidX.Legacy.Support.Core.UI.dll */
	/* uncompressed_file_size */
	.word	15872
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_37

	/* 38: Xamarin.AndroidX.Lifecycle.Common.dll */
	/* uncompressed_file_size */
	.word	15360
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_38

	/* 39: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll */
	/* uncompressed_file_size */
	.word	16384
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_39

	/* 40: Xamarin.AndroidX.Lifecycle.ViewModel.dll */
	/* uncompressed_file_size */
	.word	17408
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_40

	/* 41: Xamarin.AndroidX.Loader.dll */
	/* uncompressed_file_size */
	.word	36864
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_41

	/* 42: Xamarin.AndroidX.RecyclerView.dll */
	/* uncompressed_file_size */
	.word	424448
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_42

	/* 43: Xamarin.AndroidX.SavedState.dll */
	/* uncompressed_file_size */
	.word	13312
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_43

	/* 44: Xamarin.AndroidX.SwipeRefreshLayout.dll */
	/* uncompressed_file_size */
	.word	40448
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_44

	/* 45: Xamarin.AndroidX.ViewPager.dll */
	/* uncompressed_file_size */
	.word	57856
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_45

	/* 46: Xamarin.Essentials.dll */
	/* uncompressed_file_size */
	.word	47104
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_46

	/* 47: Xamarin.Forms.Core.dll */
	/* uncompressed_file_size */
	.word	1207296
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_47

	/* 48: Xamarin.Forms.Maps.Android.dll */
	/* uncompressed_file_size */
	.word	283568
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_48

	/* 49: Xamarin.Forms.Maps.dll */
	/* uncompressed_file_size */
	.word	24576
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_49

	/* 50: Xamarin.Forms.Platform.Android.dll */
	/* uncompressed_file_size */
	.word	934912
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_50

	/* 51: Xamarin.Forms.Platform.dll */
	/* uncompressed_file_size */
	.word	263040
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_51

	/* 52: Xamarin.Forms.Xaml.dll */
	/* uncompressed_file_size */
	.word	103424
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_52

	/* 53: Xamarin.Google.Android.Material.dll */
	/* uncompressed_file_size */
	.word	258048
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_53

	/* 54: Xamarin.Google.Guava.ListenableFuture.dll */
	/* uncompressed_file_size */
	.word	18072
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_54

	/* 55: Xamarin.GooglePlayServices.Base.dll */
	/* uncompressed_file_size */
	.word	13824
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_55

	/* 56: Xamarin.GooglePlayServices.Basement.dll */
	/* uncompressed_file_size */
	.word	20480
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_56

	/* 57: Xamarin.GooglePlayServices.Maps.dll */
	/* uncompressed_file_size */
	.word	233472
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_57

	/* 58: Xamarin.GooglePlayServices.Tasks.dll */
	/* uncompressed_file_size */
	.word	48640
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_58

	/* 59: mscorlib.dll */
	/* uncompressed_file_size */
	.word	2182656
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_59

	.size	.L.compressed_assembly_descriptors, 960
	.section	.data.compressed_assemblies,"aw",@progbits
	.type	compressed_assemblies, @object
	.p2align	3
	.global	compressed_assemblies
compressed_assemblies:
	/* count */
	.word	60
	/* descriptors */
	.zero	4
	.xword	.L.compressed_assembly_descriptors
	.size	compressed_assemblies, 16
