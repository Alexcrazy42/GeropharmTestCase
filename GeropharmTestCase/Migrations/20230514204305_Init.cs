﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeropharmTestCase.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Description1", "Project1" },
                    { 2, "Description2", "Project2" },
                    { 3, "Description3", "Project3" },
                    { 4, "Description4", "Project4" },
                    { 5, "Description5", "Project5" },
                    { 6, "Description6", "Project6" },
                    { 7, "Description7", "Project7" },
                    { 8, "Description8", "Project8" },
                    { 9, "Description9", "Project9" },
                    { 10, "Description10", "Project10" },
                    { 11, "Description11", "Project11" },
                    { 12, "Description12", "Project12" },
                    { 13, "Description13", "Project13" },
                    { 14, "Description14", "Project14" },
                    { 15, "Description15", "Project15" },
                    { 16, "Description16", "Project16" },
                    { 17, "Description17", "Project17" },
                    { 18, "Description18", "Project18" },
                    { 19, "Description19", "Project19" },
                    { 20, "Description20", "Project20" },
                    { 21, "Description21", "Project21" },
                    { 22, "Description22", "Project22" },
                    { 23, "Description23", "Project23" },
                    { 24, "Description24", "Project24" },
                    { 25, "Description25", "Project25" },
                    { 26, "Description26", "Project26" },
                    { 27, "Description27", "Project27" },
                    { 28, "Description28", "Project28" },
                    { 29, "Description29", "Project29" },
                    { 30, "Description30", "Project30" },
                    { 31, "Description31", "Project31" },
                    { 32, "Description32", "Project32" },
                    { 33, "Description33", "Project33" },
                    { 34, "Description34", "Project34" },
                    { 35, "Description35", "Project35" },
                    { 36, "Description36", "Project36" },
                    { 37, "Description37", "Project37" },
                    { 38, "Description38", "Project38" },
                    { 39, "Description39", "Project39" },
                    { 40, "Description40", "Project40" },
                    { 41, "Description41", "Project41" },
                    { 42, "Description42", "Project42" },
                    { 43, "Description43", "Project43" },
                    { 44, "Description44", "Project44" },
                    { 45, "Description45", "Project45" },
                    { 46, "Description46", "Project46" },
                    { 47, "Description47", "Project47" },
                    { 48, "Description48", "Project48" },
                    { 49, "Description49", "Project49" },
                    { 50, "Description50", "Project50" },
                    { 51, "Description51", "Project51" },
                    { 52, "Description52", "Project52" },
                    { 53, "Description53", "Project53" },
                    { 54, "Description54", "Project54" },
                    { 55, "Description55", "Project55" },
                    { 56, "Description56", "Project56" },
                    { 57, "Description57", "Project57" },
                    { 58, "Description58", "Project58" },
                    { 59, "Description59", "Project59" },
                    { 60, "Description60", "Project60" },
                    { 61, "Description61", "Project61" },
                    { 62, "Description62", "Project62" },
                    { 63, "Description63", "Project63" },
                    { 64, "Description64", "Project64" },
                    { 65, "Description65", "Project65" },
                    { 66, "Description66", "Project66" },
                    { 67, "Description67", "Project67" },
                    { 68, "Description68", "Project68" },
                    { 69, "Description69", "Project69" },
                    { 70, "Description70", "Project70" },
                    { 71, "Description71", "Project71" },
                    { 72, "Description72", "Project72" },
                    { 73, "Description73", "Project73" },
                    { 74, "Description74", "Project74" },
                    { 75, "Description75", "Project75" },
                    { 76, "Description76", "Project76" },
                    { 77, "Description77", "Project77" },
                    { 78, "Description78", "Project78" },
                    { 79, "Description79", "Project79" },
                    { 80, "Description80", "Project80" },
                    { 81, "Description81", "Project81" },
                    { 82, "Description82", "Project82" },
                    { 83, "Description83", "Project83" },
                    { 84, "Description84", "Project84" },
                    { 85, "Description85", "Project85" },
                    { 86, "Description86", "Project86" },
                    { 87, "Description87", "Project87" },
                    { 88, "Description88", "Project88" },
                    { 89, "Description89", "Project89" },
                    { 90, "Description90", "Project90" },
                    { 91, "Description91", "Project91" },
                    { 92, "Description92", "Project92" },
                    { 93, "Description93", "Project93" },
                    { 94, "Description94", "Project94" },
                    { 95, "Description95", "Project95" },
                    { 96, "Description96", "Project96" },
                    { 97, "Description97", "Project97" },
                    { 98, "Description98", "Project98" },
                    { 99, "Description99", "Project99" },
                    { 100, "Description100", "Project100" },
                    { 101, "Description101", "Project101" },
                    { 102, "Description102", "Project102" },
                    { 103, "Description103", "Project103" },
                    { 104, "Description104", "Project104" },
                    { 105, "Description105", "Project105" },
                    { 106, "Description106", "Project106" },
                    { 107, "Description107", "Project107" },
                    { 108, "Description108", "Project108" },
                    { 109, "Description109", "Project109" },
                    { 110, "Description110", "Project110" },
                    { 111, "Description111", "Project111" },
                    { 112, "Description112", "Project112" },
                    { 113, "Description113", "Project113" },
                    { 114, "Description114", "Project114" },
                    { 115, "Description115", "Project115" },
                    { 116, "Description116", "Project116" },
                    { 117, "Description117", "Project117" },
                    { 118, "Description118", "Project118" },
                    { 119, "Description119", "Project119" },
                    { 120, "Description120", "Project120" },
                    { 121, "Description121", "Project121" },
                    { 122, "Description122", "Project122" },
                    { 123, "Description123", "Project123" },
                    { 124, "Description124", "Project124" },
                    { 125, "Description125", "Project125" },
                    { 126, "Description126", "Project126" },
                    { 127, "Description127", "Project127" },
                    { 128, "Description128", "Project128" },
                    { 129, "Description129", "Project129" },
                    { 130, "Description130", "Project130" },
                    { 131, "Description131", "Project131" },
                    { 132, "Description132", "Project132" },
                    { 133, "Description133", "Project133" },
                    { 134, "Description134", "Project134" },
                    { 135, "Description135", "Project135" },
                    { 136, "Description136", "Project136" },
                    { 137, "Description137", "Project137" },
                    { 138, "Description138", "Project138" },
                    { 139, "Description139", "Project139" },
                    { 140, "Description140", "Project140" },
                    { 141, "Description141", "Project141" },
                    { 142, "Description142", "Project142" },
                    { 143, "Description143", "Project143" },
                    { 144, "Description144", "Project144" },
                    { 145, "Description145", "Project145" },
                    { 146, "Description146", "Project146" },
                    { 147, "Description147", "Project147" },
                    { 148, "Description148", "Project148" },
                    { 149, "Description149", "Project149" },
                    { 150, "Description150", "Project150" },
                    { 151, "Description151", "Project151" },
                    { 152, "Description152", "Project152" },
                    { 153, "Description153", "Project153" },
                    { 154, "Description154", "Project154" },
                    { 155, "Description155", "Project155" },
                    { 156, "Description156", "Project156" },
                    { 157, "Description157", "Project157" },
                    { 158, "Description158", "Project158" },
                    { 159, "Description159", "Project159" },
                    { 160, "Description160", "Project160" },
                    { 161, "Description161", "Project161" },
                    { 162, "Description162", "Project162" },
                    { 163, "Description163", "Project163" },
                    { 164, "Description164", "Project164" },
                    { 165, "Description165", "Project165" },
                    { 166, "Description166", "Project166" },
                    { 167, "Description167", "Project167" },
                    { 168, "Description168", "Project168" },
                    { 169, "Description169", "Project169" },
                    { 170, "Description170", "Project170" },
                    { 171, "Description171", "Project171" },
                    { 172, "Description172", "Project172" },
                    { 173, "Description173", "Project173" },
                    { 174, "Description174", "Project174" },
                    { 175, "Description175", "Project175" },
                    { 176, "Description176", "Project176" },
                    { 177, "Description177", "Project177" },
                    { 178, "Description178", "Project178" },
                    { 179, "Description179", "Project179" },
                    { 180, "Description180", "Project180" },
                    { 181, "Description181", "Project181" },
                    { 182, "Description182", "Project182" },
                    { 183, "Description183", "Project183" },
                    { 184, "Description184", "Project184" },
                    { 185, "Description185", "Project185" },
                    { 186, "Description186", "Project186" },
                    { 187, "Description187", "Project187" },
                    { 188, "Description188", "Project188" },
                    { 189, "Description189", "Project189" },
                    { 190, "Description190", "Project190" },
                    { 191, "Description191", "Project191" },
                    { 192, "Description192", "Project192" },
                    { 193, "Description193", "Project193" },
                    { 194, "Description194", "Project194" },
                    { 195, "Description195", "Project195" },
                    { 196, "Description196", "Project196" },
                    { 197, "Description197", "Project197" },
                    { 198, "Description198", "Project198" },
                    { 199, "Description199", "Project199" },
                    { 200, "Description200", "Project200" },
                    { 201, "Description201", "Project201" },
                    { 202, "Description202", "Project202" },
                    { 203, "Description203", "Project203" },
                    { 204, "Description204", "Project204" },
                    { 205, "Description205", "Project205" },
                    { 206, "Description206", "Project206" },
                    { 207, "Description207", "Project207" },
                    { 208, "Description208", "Project208" },
                    { 209, "Description209", "Project209" },
                    { 210, "Description210", "Project210" },
                    { 211, "Description211", "Project211" },
                    { 212, "Description212", "Project212" },
                    { 213, "Description213", "Project213" },
                    { 214, "Description214", "Project214" },
                    { 215, "Description215", "Project215" },
                    { 216, "Description216", "Project216" },
                    { 217, "Description217", "Project217" },
                    { 218, "Description218", "Project218" },
                    { 219, "Description219", "Project219" },
                    { 220, "Description220", "Project220" },
                    { 221, "Description221", "Project221" },
                    { 222, "Description222", "Project222" },
                    { 223, "Description223", "Project223" },
                    { 224, "Description224", "Project224" },
                    { 225, "Description225", "Project225" },
                    { 226, "Description226", "Project226" },
                    { 227, "Description227", "Project227" },
                    { 228, "Description228", "Project228" },
                    { 229, "Description229", "Project229" },
                    { 230, "Description230", "Project230" },
                    { 231, "Description231", "Project231" },
                    { 232, "Description232", "Project232" },
                    { 233, "Description233", "Project233" },
                    { 234, "Description234", "Project234" },
                    { 235, "Description235", "Project235" },
                    { 236, "Description236", "Project236" },
                    { 237, "Description237", "Project237" },
                    { 238, "Description238", "Project238" },
                    { 239, "Description239", "Project239" },
                    { 240, "Description240", "Project240" },
                    { 241, "Description241", "Project241" },
                    { 242, "Description242", "Project242" },
                    { 243, "Description243", "Project243" },
                    { 244, "Description244", "Project244" },
                    { 245, "Description245", "Project245" },
                    { 246, "Description246", "Project246" },
                    { 247, "Description247", "Project247" },
                    { 248, "Description248", "Project248" },
                    { 249, "Description249", "Project249" },
                    { 250, "Description250", "Project250" },
                    { 251, "Description251", "Project251" },
                    { 252, "Description252", "Project252" },
                    { 253, "Description253", "Project253" },
                    { 254, "Description254", "Project254" },
                    { 255, "Description255", "Project255" },
                    { 256, "Description256", "Project256" },
                    { 257, "Description257", "Project257" },
                    { 258, "Description258", "Project258" },
                    { 259, "Description259", "Project259" },
                    { 260, "Description260", "Project260" },
                    { 261, "Description261", "Project261" },
                    { 262, "Description262", "Project262" },
                    { 263, "Description263", "Project263" },
                    { 264, "Description264", "Project264" },
                    { 265, "Description265", "Project265" },
                    { 266, "Description266", "Project266" },
                    { 267, "Description267", "Project267" },
                    { 268, "Description268", "Project268" },
                    { 269, "Description269", "Project269" },
                    { 270, "Description270", "Project270" },
                    { 271, "Description271", "Project271" },
                    { 272, "Description272", "Project272" },
                    { 273, "Description273", "Project273" },
                    { 274, "Description274", "Project274" },
                    { 275, "Description275", "Project275" },
                    { 276, "Description276", "Project276" },
                    { 277, "Description277", "Project277" },
                    { 278, "Description278", "Project278" },
                    { 279, "Description279", "Project279" },
                    { 280, "Description280", "Project280" },
                    { 281, "Description281", "Project281" },
                    { 282, "Description282", "Project282" },
                    { 283, "Description283", "Project283" },
                    { 284, "Description284", "Project284" },
                    { 285, "Description285", "Project285" },
                    { 286, "Description286", "Project286" },
                    { 287, "Description287", "Project287" },
                    { 288, "Description288", "Project288" },
                    { 289, "Description289", "Project289" },
                    { 290, "Description290", "Project290" },
                    { 291, "Description291", "Project291" },
                    { 292, "Description292", "Project292" },
                    { 293, "Description293", "Project293" },
                    { 294, "Description294", "Project294" },
                    { 295, "Description295", "Project295" },
                    { 296, "Description296", "Project296" },
                    { 297, "Description297", "Project297" },
                    { 298, "Description298", "Project298" },
                    { 299, "Description299", "Project299" },
                    { 300, "Description300", "Project300" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
