# Search Cleanser
A SQL CLR function to strip diacritics and special characters for search strings. If used to strip query input, it must also be used to strip text upon indexing (ie. They must match).

### Prerequisites
CLR must be enabled before using this function
```
sp_configure 'clr enabled', 1
RECONFIGURE
```

### Installation
Once CLR function is built in Visual Studio, we can "publish" it to a script, which generates the below code that can be run.
This is for SQL 2008 and Requires .Net Framework 3.5
```
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;
GO
USE GLGLIVE

GO
CREATE ASSEMBLY [SearchCleanser]
    AUTHORIZATION [dbo]
    FROM 0x4D5A90000300000004000000FFFF0000B800000000000000400000000000000000000000000000000000000000000000000000000000000000000000800000000E1FBA0E00B409CD21B8014CCD21546869732070726F6772616D2063616E6E6F742062652072756E20696E20444F53206D6F64652E0D0D0A2400000000000000504500004C0103000BA451580000000000000000E00002210B010B00000800000006000000000000CE260000002000000040000000000010002000000002000004000000000000000400000000000000008000000002000000000000030040850000100000100000000010000010000000000000100000000000000000000000802600004B00000000400000C002000000000000000000000000000000000000006000000C000000482500001C0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000200000080000000000000000000000082000004800000000000000000000002E74657874000000D4060000002000000008000000020000000000000000000000000000200000602E72737263000000C00200000040000000040000000A0000000000000000000000000000400000402E72656C6F6300000C0000000060000000020000000E00000000000000000000000000004000004200000000000000000000000000000000B0260000000000004800000002000500D02000007804000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001330020069000000010000110002186F0500000A0A730600000A0B000613051613062B2D110511066F0700000A0C0008280800000A0D091BFE01130711072D0A0007086F0900000A260000110617581306110611056F0A00000AFE04130711072DC2076F0B00000A176F0500000A13042B0011042A1E02280C00000A2A00000042534A4201000100000000000C00000076322E302E35303732370000000005006C0000006C010000237E0000D8010000E801000023537472696E677300000000C00300000800000023555300C8030000100000002347554944000000D8030000A000000023426C6F620000000000000002000001471502000900000000FA253300160000010000000B0000000200000002000000010000000C0000000400000001000000010000000200000000000A00010000000000060042003B00060072005F000B00860000000600B50095000600D50095000A0029010E0106003E013B0006005101450106006D01450106009A0185010600AA0185010000000001000000000001000100010010001D000000050001000100502000000000960049000A000100C52000000000861854000F000200000001005A00110054001300210054001900290054000F00310054000F00390063014300490054000F0039007B0149005100BA014E004900CD0154003900D4015A000900DF015E00090054000F00200023001E002E000B006F002E00130078002E001B0081006200048000000000000000000000000000000000F3000000020000000000000000000000010032000000000002000000000000000000000001000201000000000000003C4D6F64756C653E00536561726368436C65616E7365722E646C6C0055736572446566696E656446756E6374696F6E73006D73636F726C69620053797374656D004F626A6563740053747269704368617273002E63746F7200746578740053797374656D2E446961676E6F73746963730044656275676761626C6541747472696275746500446562756767696E674D6F6465730053797374656D2E52756E74696D652E436F6D70696C6572536572766963657300436F6D70696C6174696F6E52656C61786174696F6E734174747269627574650052756E74696D65436F6D7061746962696C69747941747472696275746500536561726368436C65616E7365720053797374656D2E44617461004D6963726F736F66742E53716C5365727665722E5365727665720053716C46756E6374696F6E41747472696275746500537472696E670053797374656D2E54657874004E6F726D616C697A6174696F6E466F726D004E6F726D616C697A6500537472696E674275696C646572006765745F43686172730053797374656D2E476C6F62616C697A6174696F6E0043686172556E69636F6465496E666F00556E69636F646543617465676F727900476574556E69636F646543617465676F727900417070656E64006765745F4C656E67746800546F537472696E6700000320000000000078B263062AB31946BB2490FE9B1D1F6B0008B77A5C561934E0890400010E0E0320000105200101110D0420010108240100020054020F497344657465726D696E697374696301540209497350726563697365010520010E11210420010308050001112D03052001122503032000080320000E0C07080E122503112D0E0E08020801000701000000000801000800000000001E01000100540216577261704E6F6E457863657074696F6E5468726F777301000000000BA4515800000000020000001C0100006425000064070000525344530D5FC1F9600213449CBDE344EB7EA83003000000633A5C55736572735C41646D696E6973747261746F725C446F63756D656E74735C56697375616C2053747564696F20323031355C50726F6A656374735C536561726368436C65616E7365725C536561726368436C65616E7365725C6F626A5C44656275675C536561726368436C65616E7365722E706462000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000A82600000000000000000000BE260000002000000000000000000000000000000000000000000000B02600000000000000005F436F72446C6C4D61696E006D73636F7265652E646C6C0000000000FF250020001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000100100000001800008000000000000000000000000000000100010000003000008000000000000000000000000000000100000000004800000058400000640200000000000000000000640234000000560053005F00560045005200530049004F004E005F0049004E0046004F0000000000BD04EFFE00000100000000000000000000000000000000003F000000000000000400000002000000000000000000000000000000440000000100560061007200460069006C00650049006E0066006F00000000002400040000005400720061006E0073006C006100740069006F006E00000000000000B004C4010000010053007400720069006E006700460069006C00650049006E0066006F000000A001000001003000300030003000300034006200300000002C0002000100460069006C0065004400650073006300720069007000740069006F006E000000000020000000300008000100460069006C006500560065007200730069006F006E000000000030002E0030002E0030002E003000000048001300010049006E007400650072006E0061006C004E0061006D006500000053006500610072006300680043006C00650061006E007300650072002E0064006C006C00000000002800020001004C006500670061006C0043006F0070007900720069006700680074000000200000005000130001004F0072006900670069006E0061006C00460069006C0065006E0061006D006500000053006500610072006300680043006C00650061006E007300650072002E0064006C006C0000000000340008000100500072006F006400750063007400560065007200730069006F006E00000030002E0030002E0030002E003000000038000800010041007300730065006D0062006C0079002000560065007200730069006F006E00000030002E0030002E0030002E0030000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000C000000D03600000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000;


GO
ALTER ASSEMBLY [SearchCleanser]
    DROP FILE ALL
    ADD FILE FROM 0x4D6963726F736F667420432F432B2B204D534620372E30300D0A1A445300000000020000020000001B00000080000000000000001800000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000020ECE7FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF180218FEFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF0BCA3101380000000010000000100000000000000F00FFFF04000000038000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000BCA3101380000000010000000100000000000001000FFFF0400000003800000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000F862513FC607D311905300C04FA302A1C4454B99E9E6D211903F00C04FA302A10B9D865A1166D311BD2A0000F80849BD60A66E40CF64824CB6F042D48172A799100000000000000073CE18B038EF4B4D61C433B260C9B4E9000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000BCA310138000000001000000010000000000000FFFFFFFF040000000380000000000000FFFFFFFF00000000FFFFFFFF00000000FFFFFFFF0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000BCA310138000000001000000010000000000000FFFFFFFF040000000380000000000000FFFFFFFF00000000FFFFFFFF00000000FFFFFFFF000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000F862513FC607D311905300C04FA302A1C4454B99E9E6D211903F00C04FA302A10B9D865A1166D311BD2A0000F80849BD60A66E40CF64824CB6F042D48172A7991000000000000000D40F3604E61E910F9E19A39651D4A474000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001BE23001AC000000B8475BB54356D2010200000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000200000004000000010000000A0000000000000045010000280000001BE23001EC1F704558000000DC0000006E000000450100006500000000000000000000006F000000280000001BE23001FC0DBD1858000000010000006E0000006F00000065000000000000000000000031355C70726F6A656374735C646961637269746963636C65616E65725C646961637269746963636C65616E65725C737472697063686172732E637300040000006E00000000000000010000006F000000030000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000006900000000000000690000000000000000000000000000000000000000000000280000009C0300002C0200002C000000340000005800000017000000030000000600000015000000070000000C0000000900000008000000050000000D0000000E0000000F000000100000001200000011000000040000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001BE23001AC0000001C66153B4456D2010300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000200000004000000010000000A0000000000000045010000280000001BE230012C7FAEEA58000000DC0000006E000000450100006500000000000000000000006F000000280000001BE23001FC0DBD1858000000010000006E0000006F00000065000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000FEEFFEEF01000000AE01000000633A5C55736572735C41646D696E6973747261746F725C446F63756D656E74735C56697375616C2053747564696F20323031355C50726F6A656374735C446961637269746963436C65616E65725C446961637269746963436C65616E65725C537472697043686172732E63730000633A5C75736572735C61646D696E6973747261746F725C646F63756D656E74735C76697375616C2073747564696F20323031355C70726F6A656374735C646961637269746963636C65616E65725C646961637269746963636C65616E65725C737472697063686172732E637300633A5C55736572735C41646D696E6973747261746F725C446F63756D656E74735C56697375616C2053747564696F20323031355C50726F6A656374735C536561726368436C65616E7365725C536561726368436C65616E7365725C537472697043686172732E637300633A5C75736572735C61646D696E6973747261746F725C646F63756D656E74735C76697375616C2073747564696F20323031355C70726F6A656374735C736561726368636C65616E7365725C736561726368636C65616E7365725C737472697063686172732E63730007000000450100006E0000000000000000000000DC000000010000006F00000005000000000000000000000000000000000000000000000000000000000000000000000000000400000032002A11000000006C020000000000006900000000000000000000000100000600000000010000000053747269704368617273001600031104000000380200006900000000000000010000000A0024115553797374656D00120024115553797374656D2E4461746100000000120024115553797374656D2E54657874000000001A0024115553797374656D2E476C6F62616C697A6174696F6E0000001A0024115553797374656D2E446174612E53716C436C69656E7400001A0024115553797374656D2E446174612E53716C54797065730000001E002411554D6963726F736F66742E53716C5365727665722E536572766572001E002011040000000100001100000000000004004353243124303030300000001E002011050000000100001100000000000004004353243624303030310000001E002011060000000100001100000000000004004353243724303030320000001E0020110700000001000011000000000000040043532434243030303300000026002011000000000100001100000000000000006E6F726D616C697A6564537472696E67000000002200201101000000010000110000000000000000737472696E674275696C64657200000016000311380000003402000027000000180000000100000016002011020000000100001100000000000000006300000016000311C4010000300200001D00000022000000010000002200201103000000010000110000000000000000756E69636F646543617465676F7279000200060002000600020006002E000404C93FEAC6B359D649BC250902BBABB460000000004D0044003200000004010000040000000C0000000100070002000600F2000000080100000000000001000100690000000000000014000000FC000000000000000D000080010000000E000080090000000F0000800F00000011000080100000001100008013000000EEEFFE801800000011000080220000001200008023000000130000802A0000001400008030000000EEEFFE80340000001500008035000000160000803D000000170000803E000000180000803F000000EEEFFE80450000001100008052000000EEEFFE80560000001A000080660000001B000080050006000900480009003100090010001B002B00000000001200170009000A000D0049000D004300000000000D000E00110029000D000E0009000A000000000018001A000000000009004C0005000600F400000008000000DC0000000000000008000000000000001C00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000FFFFFFFF1A092FF1100000000C0200001D000000010000000100000001000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000C0000003030303030310000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001A0025110000000004000000010053747269704368617273000000001600291100000000040000000100303630303030303100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000000000000000000000000000000000000000000000000000000FFFFFFFF1A092FF100000000000000003030303030310000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000F000000800000007201000038000000FFFFFFFF3800000000000000DE010000AC00000058000000FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF580000000A0000000300000006000000070000000C000000090000000800000004000000746F725C646F63756D656E74735C76697375616C2073747564696F20323031355C70726F6A656374735C646961637269746963636C65616E65725C646961637269746963636C65616E65725C737472697063686172732E6373000400000006000000010000003A0000000000000011000000070000000A0000000600000000000000050000002200000008000000000000004191320100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001300000020000000F600000038000000970100003800000000000000000100008000000058000000280000009C0300002C0200002C0000003400000003000000130000000600000012000000070000000A0000000B00000008000000090000000C0000000D0000000E0000000F00000011000000100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000FFFFFFFF77093101030000000B00008C0C0046510D00A08260000000200000002C00000078000000000000000000000016000000190000000000EEC00000000000000000FFFF000000000000FFFFFFFF00000000FFFF0000000000000000000000000A007002000000000000200100000100000078FBF900000000000000000055736572446566696E656446756E6374696F6E730037314141414545380000002DBA2EF101000000000000006900000000000000000000000000000000000000020002000D01000000000100FFFFFFFF00000000690000000802000000000000FFFFFFFF00000000FFFFFFFF010001000000010000000000633A5C55736572735C41646D696E6973747261746F725C446F63756D656E74735C56697375616C2053747564696F20323031355C50726F6A656374735C536561726368436C65616E7365725C536561726368436C65616E7365725C537472697043686172732E637300000000FEEFFEEF010000000100000000010000000000000000000000FFFFFFFFFFFFFFFFFFFF0900FFFFFFFFFFFFFFFFFFFF20323031355C50726F6A656374735C536561726368436C65616E7365725C536561726368436C65616E7365725C537472697043686172732E6373000000FEEFFEEF010000000100000000010000000000000000000000FFFFFFFFFFFFFFFFFFFF0900FFFFFFFFFFFFFFFFFFFF00942E310106A05158030000000D5FC1F9600213449CBDE344EB7EA8300E0100002F4C696E6B496E666F002F6E616D6573002F7372632F686561646572626C6F636B002F7372632F66696C65732F633A5C75736572735C61646D696E6973747261746F725C646F63756D656E74735C76697375616C2073747564696F20323031355C70726F6A656374735C646961637269746963636C65616E65725C646961637269746963636C65616E65725C737472697063686172732E6373002F7372632F66696C65732F633A5C75736572735C61646D696E6973747261746F725C646F63756D656E74735C76697375616C2073747564696F20323031355C70726F6A656374735C736561726368636C65616E7365725C736561726368636C65616E7365725C737472697063686172732E637300050000000A000000010000002E0200000000000011000000070000009A0000000E00000000000000050000000A0000000600000022000000080000000000000041913201000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000F000000600000007201000038000000930100003800000000000000DE010000AC00000058000000280000009C0300002C0200002C000000340000005800000013000000160000000600000015000000070000000C0000000B000000080000000A0000000D0000000E0000000F00000010000000120000001100000005000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000170000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000 AS N'SearchCleanser.pdb';


GO
PRINT N'Creating [dbo].[StripChars]...';

GO
CREATE FUNCTION [dbo].[StripChars]
(@text NVARCHAR (MAX))
RETURNS NVARCHAR (MAX)
AS
 EXTERNAL NAME [SearchCleanser].[UserDefinedFunctions].[StripChars]


GO
PRINT N'Update complete.';
```


### Testing
```
select [dbo].StripChars('crème brûlée')
```
Should return `creme brulee`
