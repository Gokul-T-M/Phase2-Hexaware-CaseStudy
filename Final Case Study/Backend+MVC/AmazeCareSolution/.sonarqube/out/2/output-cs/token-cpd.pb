ý
gC:\Users\gokul\OneDrive\Desktop\C#_workspace\AmazeCareSolution\AmazeCare.BLL\Services\PatientService.cs
	namespace

 	
	AmazeCare


 
.

 
BLL

 
.

 
Services

  
{ 
public 

class 
PatientService 
:  !
IPatientService" 1
{ 
private 
readonly 
IPatientRepository +
_patientRepository, >
;> ?
public 
PatientService 
( 
IPatientRepository 0
patientRepository1 B
)B C
{ 	
_patientRepository 
=  
patientRepository! 2
;2 3
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
Patient& -
>- .
>. /
GetAllPatientsAsync0 C
(C D
)D E
{ 	
return 
await 
_patientRepository +
.+ ,
GetAllAsync, 7
(7 8
)8 9
;9 :
} 	
public 
async 
Task 
< 
Patient !
?! "
>" #
GetPatientByIdAsync$ 7
(7 8
int8 ;
id< >
)> ?
{ 	
return 
await 
_patientRepository +
.+ ,
GetByIdAsync, 8
(8 9
id9 ;
); <
;< =
} 	
public 
async 
Task 
AddPatientAsync )
() *
Patient* 1
patient2 9
)9 :
{   	
await!! 
_patientRepository!! $
.!!$ %
AddAsync!!% -
(!!- .
patient!!. 5
)!!5 6
;!!6 7
await"" 
_patientRepository"" $
.""$ %
	SaveAsync""% .
("". /
)""/ 0
;""0 1
}## 	
public%% 
async%% 
Task%% 
UpdatePatientAsync%% ,
(%%, -
Patient%%- 4
patient%%5 <
)%%< =
{&& 	
_patientRepository'' 
.'' 
Update'' %
(''% &
patient''& -
)''- .
;''. /
await(( 
_patientRepository(( $
.(($ %
	SaveAsync((% .
(((. /
)((/ 0
;((0 1
})) 	
public++ 
async++ 
Task++ 
DeletePatientAsync++ ,
(++, -
int++- 0
id++1 3
)++3 4
{,, 	
var-- 
patient-- 
=-- 
await-- 
_patientRepository--  2
.--2 3
GetByIdAsync--3 ?
(--? @
id--@ B
)--B C
;--C D
if.. 
(.. 
patient.. 
!=.. 
null.. 
)..  
{// 
_patientRepository00 "
.00" #
Delete00# )
(00) *
patient00* 1
)001 2
;002 3
await11 
_patientRepository11 (
.11( )
	SaveAsync11) 2
(112 3
)113 4
;114 5
}22 
}33 	
}44 
}55 Ú
fC:\Users\gokul\OneDrive\Desktop\C#_workspace\AmazeCareSolution\AmazeCare.BLL\Services\DoctorService.cs
	namespace

 	
	AmazeCare


 
.

 
BLL

 
.

 
Services

  
{ 
public 

class 
DoctorService 
:  
IDoctorService! /
{ 
private 
readonly 
IDoctorRepository *
_doctorRepository+ <
;< =
public 
DoctorService 
( 
IDoctorRepository .
doctorRepository/ ?
)? @
{ 	
_doctorRepository 
= 
doctorRepository  0
;0 1
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
Doctor& ,
>, -
>- .
GetAllDoctorsAsync/ A
(A B
)B C
{ 	
return 
await 
_doctorRepository *
.* +
GetAllAsync+ 6
(6 7
)7 8
;8 9
} 	
public 
async 
Task 
< 
Doctor  
?  !
>! "
GetDoctorByIdAsync# 5
(5 6
int6 9
id: <
)< =
{ 	
return 
await 
_doctorRepository *
.* +
GetByIdAsync+ 7
(7 8
id8 :
): ;
;; <
} 	
public 
async 
Task 
AddDoctorAsync (
(( )
Doctor) /
doctor0 6
)6 7
{   	
await!! 
_doctorRepository!! #
.!!# $
AddAsync!!$ ,
(!!, -
doctor!!- 3
)!!3 4
;!!4 5
await"" 
_doctorRepository"" #
.""# $
	SaveAsync""$ -
(""- .
)"". /
;""/ 0
}## 	
public%% 
async%% 
Task%% 
UpdateDoctorAsync%% +
(%%+ ,
Doctor%%, 2
doctor%%3 9
)%%9 :
{&& 	
_doctorRepository'' 
.'' 
Update'' $
(''$ %
doctor''% +
)''+ ,
;'', -
await(( 
_doctorRepository(( #
.((# $
	SaveAsync(($ -
(((- .
)((. /
;((/ 0
})) 	
public++ 
async++ 
Task++ 
DeleteDoctorAsync++ +
(+++ ,
int++, /
id++0 2
)++2 3
{,, 	
var-- 
doctor-- 
=-- 
await-- 
_doctorRepository-- 0
.--0 1
GetByIdAsync--1 =
(--= >
id--> @
)--@ A
;--A B
if.. 
(.. 
doctor.. 
!=.. 
null.. 
).. 
{// 
_doctorRepository00 !
.00! "
Delete00" (
(00( )
doctor00) /
)00/ 0
;000 1
await11 
_doctorRepository11 '
.11' (
	SaveAsync11( 1
(111 2
)112 3
;113 4
}22 
}33 	
}66 
}77 ¡#
kC:\Users\gokul\OneDrive\Desktop\C#_workspace\AmazeCareSolution\AmazeCare.BLL\Services\AppointmentService.cs
	namespace

 	
	AmazeCare


 
.

 
BLL

 
.

 
Services

  
{ 
public 

class 
AppointmentService #
:$ %
IAppointmentService& 9
{ 
private 
readonly "
IAppointmentRepository /"
_appointmentRepository0 F
;F G
public 
AppointmentService !
(! ""
IAppointmentRepository" 8!
appointmentRepository9 N
)N O
{ 	"
_appointmentRepository "
=# $!
appointmentRepository% :
;: ;
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
Appointment& 1
>1 2
>2 3#
GetAllAppointmentsAsync4 K
(K L
)L M
{ 	
return 
await "
_appointmentRepository /
./ 0"
GetAllWithDetailsAsync0 F
(F G
)G H
;H I
} 	
public 
async 
Task 
< 
Appointment %
?% &
>& '#
GetAppointmentByIdAsync( ?
(? @
int@ C
idD F
)F G
{ 	
return 
await "
_appointmentRepository /
./ 0#
GetByIdWithDetailsAsync0 G
(G H
idH J
)J K
;K L
} 	
public 
async 
Task 
AddAppointmentAsync -
(- .
Appointment. 9
appointment: E
)E F
{   	
await!! "
_appointmentRepository!! (
.!!( )
AddAsync!!) 1
(!!1 2
appointment!!2 =
)!!= >
;!!> ?
await"" "
_appointmentRepository"" (
.""( )
	SaveAsync"") 2
(""2 3
)""3 4
;""4 5
}## 	
public%% 
async%% 
Task%% "
UpdateAppointmentAsync%% 0
(%%0 1
Appointment%%1 <
appointment%%= H
)%%H I
{&& 	"
_appointmentRepository'' "
.''" #
Update''# )
('') *
appointment''* 5
)''5 6
;''6 7
await(( "
_appointmentRepository(( (
.((( )
	SaveAsync(() 2
(((2 3
)((3 4
;((4 5
})) 	
public++ 
async++ 
Task++ "
DeleteAppointmentAsync++ 0
(++0 1
int++1 4
id++5 7
)++7 8
{,, 	
var-- 
appointment-- 
=-- 
await-- #"
_appointmentRepository--$ :
.--: ;
GetByIdAsync--; G
(--G H
id--H J
)--J K
;--K L
if.. 
(.. 
appointment.. 
!=.. 
null.. #
)..# $
{// "
_appointmentRepository00 &
.00& '
Delete00' -
(00- .
appointment00. 9
)009 :
;00: ;
await11 "
_appointmentRepository11 ,
.11, -
	SaveAsync11- 6
(116 7
)117 8
;118 9
}22 
}33 	
public55 
async55 
Task55 
<55 
IEnumerable55 %
<55% &
Appointment55& 1
>551 2
>552 3*
GetAppointmentsByDoctorIdAsync554 R
(55R S
int55S V
doctorId55W _
)55_ `
{66 	
return77 
await77 "
_appointmentRepository77 /
.77/ 0*
GetAppointmentsByDoctorIdAsync770 N
(77N O
doctorId77O W
)77W X
;77X Y
}88 	
public:: 
async:: 
Task:: 
<:: 
IEnumerable:: %
<::% &
Appointment::& 1
>::1 2
>::2 3+
GetAppointmentsByPatientIdAsync::4 S
(::S T
int::T W
	patientId::X a
)::a b
{;; 	
return<< 
await<< "
_appointmentRepository<< /
.<</ 0+
GetAppointmentsByPatientIdAsync<<0 O
(<<O P
	patientId<<P Y
)<<Y Z
;<<Z [
}== 	
}?? 
}@@ ·
eC:\Users\gokul\OneDrive\Desktop\C#_workspace\AmazeCareSolution\AmazeCare.BLL\Services\AdminService.cs
	namespace

 	
	AmazeCare


 
.

 
BLL

 
.

 
Services

  
{ 
public 

class 
AdminService 
: 
IAdminService  -
{ 
private 
readonly 
IAdminRepository )
_adminRepository* :
;: ;
public 
AdminService 
( 
IAdminRepository ,
adminRepository- <
)< =
{ 	
_adminRepository 
= 
adminRepository .
;. /
} 	
public 
async 
Task 
< 
IEnumerable %
<% &
Admin& +
>+ ,
>, -
GetAllAdminsAsync. ?
(? @
)@ A
{ 	
return 
await 
_adminRepository )
.) *
GetAllAsync* 5
(5 6
)6 7
;7 8
} 	
public 
async 
Task 
< 
Admin 
?  
>  !
GetAdminByIdAsync" 3
(3 4
int4 7
id8 :
): ;
{ 	
return 
await 
_adminRepository )
.) *
GetByIdAsync* 6
(6 7
id7 9
)9 :
;: ;
} 	
public 
async 
Task 
AddAdminAsync '
(' (
Admin( -
admin. 3
)3 4
{   	
await!! 
_adminRepository!! "
.!!" #
AddAsync!!# +
(!!+ ,
admin!!, 1
)!!1 2
;!!2 3
await"" 
_adminRepository"" "
.""" #
	SaveAsync""# ,
("", -
)""- .
;"". /
}## 	
public%% 
async%% 
Task%% 
UpdateAdminAsync%% *
(%%* +
Admin%%+ 0
admin%%1 6
)%%6 7
{&& 	
_adminRepository'' 
.'' 
Update'' #
(''# $
admin''$ )
)'') *
;''* +
await(( 
_adminRepository(( "
.((" #
	SaveAsync((# ,
(((, -
)((- .
;((. /
})) 	
public++ 
async++ 
Task++ 
DeleteAdminAsync++ *
(++* +
int+++ .
id++/ 1
)++1 2
{,, 	
var-- 
admin-- 
=-- 
await-- 
_adminRepository-- .
.--. /
GetByIdAsync--/ ;
(--; <
id--< >
)--> ?
;--? @
if.. 
(.. 
admin.. 
!=.. 
null.. 
).. 
{// 
_adminRepository00  
.00  !
Delete00! '
(00' (
admin00( -
)00- .
;00. /
await11 
_adminRepository11 &
.11& '
	SaveAsync11' 0
(110 1
)111 2
;112 3
}22 
}33 	
}44 
}55 û
jC:\Users\gokul\OneDrive\Desktop\C#_workspace\AmazeCareSolution\AmazeCare.BLL\Interfaces\IPatientService.cs
	namespace 	
	AmazeCare
 
. 
BLL 
. 

Interfaces "
{		 
public

 

	interface

 
IPatientService

 $
{ 
Task 
< 
IEnumerable 
< 
Patient  
>  !
>! "
GetAllPatientsAsync# 6
(6 7
)7 8
;8 9
Task 
< 
Patient 
? 
> 
GetPatientByIdAsync *
(* +
int+ .
id/ 1
)1 2
;2 3
Task 
AddPatientAsync 
( 
Patient $
patient% ,
), -
;- .
Task 
UpdatePatientAsync 
(  
Patient  '
patient( /
)/ 0
;0 1
Task 
DeletePatientAsync 
(  
int  #
id$ &
)& '
;' (
} 
} î
iC:\Users\gokul\OneDrive\Desktop\C#_workspace\AmazeCareSolution\AmazeCare.BLL\Interfaces\IDoctorService.cs
	namespace 	
	AmazeCare
 
. 
BLL 
. 

Interfaces "
{		 
public

 

	interface

 
IDoctorService

 #
{ 
Task 
< 
IEnumerable 
< 
Doctor 
>  
>  !
GetAllDoctorsAsync" 4
(4 5
)5 6
;6 7
Task 
< 
Doctor 
? 
> 
GetDoctorByIdAsync (
(( )
int) ,
id- /
)/ 0
;0 1
Task 
AddDoctorAsync 
( 
Doctor "
doctor# )
)) *
;* +
Task 
UpdateDoctorAsync 
( 
Doctor %
doctor& ,
), -
;- .
Task 
DeleteDoctorAsync 
( 
int "
id# %
)% &
;& '
} 
} ±
nC:\Users\gokul\OneDrive\Desktop\C#_workspace\AmazeCareSolution\AmazeCare.BLL\Interfaces\IAppointmentService.cs
	namespace 	
	AmazeCare
 
. 
BLL 
. 

Interfaces "
{		 
public

 

	interface

 
IAppointmentService

 (
{ 
Task 
< 
IEnumerable 
< 
Appointment $
>$ %
>% &#
GetAllAppointmentsAsync' >
(> ?
)? @
;@ A
Task 
< 
Appointment 
? 
> #
GetAppointmentByIdAsync 2
(2 3
int3 6
id7 9
)9 :
;: ;
Task 
AddAppointmentAsync  
(  !
Appointment! ,
appointment- 8
)8 9
;9 :
Task "
UpdateAppointmentAsync #
(# $
Appointment$ /
appointment0 ;
); <
;< =
Task "
DeleteAppointmentAsync #
(# $
int$ '
id( *
)* +
;+ ,
Task 
< 
IEnumerable 
< 
Appointment $
>$ %
>% &*
GetAppointmentsByDoctorIdAsync' E
(E F
intF I
doctorIdJ R
)R S
;S T
Task 
< 
IEnumerable 
< 
Appointment $
>$ %
>% &+
GetAppointmentsByPatientIdAsync' F
(F G
intG J
	patientIdK T
)T U
;U V
} 
} á
hC:\Users\gokul\OneDrive\Desktop\C#_workspace\AmazeCareSolution\AmazeCare.BLL\Interfaces\IAdminService.cs
	namespace 	
	AmazeCare
 
. 
BLL 
. 

Interfaces "
{		 
public

 

	interface

 
IAdminService

 "
{ 
Task 
< 
IEnumerable 
< 
Admin 
> 
>  
GetAllAdminsAsync! 2
(2 3
)3 4
;4 5
Task 
< 
Admin 
? 
> 
GetAdminByIdAsync &
(& '
int' *
id+ -
)- .
;. /
Task 
AddAdminAsync 
( 
Admin  
admin! &
)& '
;' (
Task 
UpdateAdminAsync 
( 
Admin #
admin$ )
)) *
;* +
Task 
DeleteAdminAsync 
( 
int !
id" $
)$ %
;% &
} 
} —
VC:\Users\gokul\OneDrive\Desktop\C#_workspace\AmazeCareSolution\AmazeCare.BLL\Class1.cs
	namespace 	
	AmazeCare
 
. 
BLL 
{ 
public 

class 
Class1 
{ 
} 
} 