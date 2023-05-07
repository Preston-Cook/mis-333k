using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Candid.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            var passwordHasher = new PasswordHasher<IdentityUser>();


            // Seed Roles
            List<IdentityRole> Roles = new List<IdentityRole>();

            var AdminRole = new IdentityRole("Admin");
            AdminRole.NormalizedName = AdminRole.Name.ToUpper();
            Roles.Add(AdminRole);

            var RecruiterRole = new IdentityRole("Recruiter");
            RecruiterRole.NormalizedName = RecruiterRole.Name.ToUpper();
            Roles.Add(RecruiterRole);

            var StudentRole = new IdentityRole("Student");
            StudentRole.NormalizedName = StudentRole.Name.ToUpper();
            Roles.Add(StudentRole);

            builder.Entity<IdentityRole>().HasData(Roles);

            // Seed Majors
            List<Major> Majors = new List<Major>();

            var major1 = new Major
            {
                MajorId = 1,
                MajorName = "Accounting",
                MajorCode = MajorCodes.ACC
            };
            Majors.Add(major1);

            var major2 = new Major
            {
                MajorId = 2,
                MajorName = "Canfield Business Honors Program",
                MajorCode = MajorCodes.CBHP
            };
            Majors.Add(major2);

            var major3 = new Major
            {
                MajorId = 3,
                MajorName = "Finance",
                MajorCode = MajorCodes.FIN
            };
            Majors.Add(major3);

            var major4 = new Major
            {
                MajorId = 4,
                MajorName = "International Business",
                MajorCode = MajorCodes.IB
            };
            Majors.Add(major4);

            var major5 = new Major
            {
                MajorId = 5,
                MajorName = "Management",
                MajorCode = MajorCodes.MAN
            };
            Majors.Add(major5);

            var major6 = new Major
            {
                MajorId = 6,
                MajorName = "Marketing",
                MajorCode = MajorCodes.MKT
            };
            Majors.Add(major6);

            var major7 = new Major
            {
                MajorId = 7,
                MajorName = "Supply Chain Management",
                MajorCode = MajorCodes.SCM
            };
            Majors.Add(major7);

            var major8 = new Major
            {
                MajorId = 8,
                MajorName = "Management Information Systems",
                MajorCode = MajorCodes.MIS
            };
            Majors.Add(major8);

            var major9 = new Major
            {
                MajorId = 9,
                MajorName = "Science and Technology Management",
                MajorCode = MajorCodes.STM
            };
            Majors.Add(major9);

            builder.Entity<Major>().HasData(Majors);

            // Seed Industries
            List<Industry> Industries = new List<Industry>();

            var ind1 = new Industry
            {
                IndustryId = 1,
                IndustryType = IndustryTypes.Accounting
            };
            Industries.Add(ind1);

            var ind2 = new Industry
            {
                IndustryId = 2,
                IndustryType = IndustryTypes.Consulting
            };
            Industries.Add(ind2);

            var ind3 = new Industry
            {
                IndustryId = 3,
                IndustryType = IndustryTypes.Energy
            };
            Industries.Add(ind3);

            var ind4 = new Industry
            {
                IndustryId = 4,
                IndustryType = IndustryTypes.Engineering
            };
            Industries.Add(ind4);

            var ind5 = new Industry
            {
                IndustryId = 5,
                IndustryType = IndustryTypes.FinancialServices
            };
            Industries.Add(ind5);

            var ind6 = new Industry
            {
                IndustryId = 6,
                IndustryType = IndustryTypes.Manufacturing
            };
            Industries.Add(ind6);

            var ind7 = new Industry
            {
                IndustryId = 7,
                IndustryType = IndustryTypes.Hospitality
            };
            Industries.Add(ind7);

            var ind8 = new Industry
            {
                IndustryId = 8,
                IndustryType = IndustryTypes.Insurance
            };
            Industries.Add(ind8);

            var ind9 = new Industry
            {
                IndustryId = 9,
                IndustryType = IndustryTypes.Marketing
            };
            Industries.Add(ind9);

            var ind10 = new Industry
            {
                IndustryId = 10,
                IndustryType = IndustryTypes.RealEstate
            };
            Industries.Add(ind10);

            var ind11 = new Industry
            {
                IndustryId = 11,
                IndustryType = IndustryTypes.Technology
            };
            Industries.Add(ind11);

            var ind12 = new Industry
            {
                IndustryId = 12,
                IndustryType = IndustryTypes.Retail
            };
            Industries.Add(ind12);

            var ind13 = new Industry
            {
                IndustryId = 13,
                IndustryType = IndustryTypes.Transportation
            };
            Industries.Add(ind13);

            var ind14 = new Industry
            {
                IndustryId = 14,
                IndustryType = IndustryTypes.Chemicals
            };
            Industries.Add(ind14);

            builder.Entity<Industry>().HasData(Industries);


            // Seed Addresses
            List<Address> Addresses = new List<Address>();

            var addr1 = new Address
            {
                AddressId = 1,
                City = "San Francisco",
                Street = "415 Mission St",
                PostalCode = "94105",
                State = StateType.CA,
                Lat = 37.7897965m,
                Lng = -122.3969499m,
            };
            Addresses.Add(addr1);

            var addr2 = new Address
            {
                AddressId = 2,
                City = "Houston",
                Street = "415 Highway 6 South",
                PostalCode = "77082-3101",
                State = StateType.TX,
                Lat = 29.7822672m,
                Lng = -95.64439809999999m,
            };
            Addresses.Add(addr2);

            var addr3 = new Address
            {
                AddressId = 3,
                City = "Austin",
                Street = "500 West 2nd Street Suite 1600",
                PostalCode = "78701",
                State = StateType.TX,
                Lat = 30.2658983m,
                Lng = -97.7493573m,
            };
            Addresses.Add(addr3);

            var addr4 = new Address
            {
                AddressId = 4,
                City = "McLean",
                Street = "1680 Capital One Dr",
                PostalCode = "22102-3491",
                State = StateType.VA,
                Lat = 38.92425739999999m,
                Lng = -77.21347999999999m,
            };
            Addresses.Add(addr4);

            var addr5 = new Address
            {
                AddressId = 5,
                City = "Dallas",
                Street = "12500 TI Blvd",
                PostalCode = "75243",
                State = StateType.TX,
                Lat = 32.910939m,
                Lng = -96.75466499999999m,
            };
            Addresses.Add(addr5);

            var addr6 = new Address
            {
                AddressId = 6,
                City = "McLean",
                Street = "7930 Jones Branch Dr",
                PostalCode = "22102",
                State = StateType.VA,
                Lat = 38.9270956m,
                Lng = -77.2151868m,
            };
            Addresses.Add(addr6);

            var addr7 = new Address
            {
                AddressId = 7,
                City = "Chicago",
                Street = "200 E Randolph St",
                PostalCode = "60601",
                State = StateType.IL,
                Lat = 41.884798m,
                Lng = -87.62124589999999m,
            };
            Addresses.Add(addr7);

            var addr8 = new Address
            {
                AddressId = 8,
                City = "Austin",
                Street = "1300 Guadalupe St",
                PostalCode = "78701",
                State = StateType.TX,
                Lat = 30.2761867m,
                Lng = -97.7437736m,
            };
            Addresses.Add(addr8);

            var addr9 = new Address
            {
                AddressId = 9,
                City = "Austin",
                Street = "515 Congress Ave Suite 2100",
                PostalCode = "78701",
                State = StateType.TX,
                Lat = 30.2677245m,
                Lng = -97.7426175m,
            };
            Addresses.Add(addr9);

            var addr10 = new Address
            {
                AddressId = 10,
                City = "Redmond",
                Street = "1 Microsoft Way",
                PostalCode = "98052",
                State = StateType.WA,
                Lat = 47.6393783m,
                Lng = -122.1282593m,
            };
            Addresses.Add(addr10);

            var addr11 = new Address
            {
                AddressId = 11,
                City = "Katy",
                Street = "1800 North Mason Road",
                PostalCode = "77449",
                State = StateType.TX,
                Lat = 29.7997717m,
                Lng = -95.7494015m,
            };
            Addresses.Add(addr11);

            var addr12 = new Address
            {
                AddressId = 12,
                City = "Chicago",
                Street = "233 S Wacker Dr",
                PostalCode = "60606",
                State = StateType.IL,
                Lat = 41.878474m,
                Lng = -87.6363853m,
            };
            Addresses.Add(addr12);

            var addr13 = new Address
            {
                AddressId = 13,
                City = "Minneapolis",
                Street = "1000 Nicollet Mall",
                PostalCode = "55403",
                State = StateType.MN,
                Lat = 44.9741779m,
                Lng = -93.27559649999999m,
            };
            Addresses.Add(addr13);

            var addr14 = new Address
            {
                AddressId = 14,
                City = "Austin",
                Street = "1 David Park",
                PostalCode = "78705",
                State = StateType.TX,
                Lat = 30.2961708m,
                Lng = -97.73895429999999m,
            };
            Addresses.Add(addr14);

            var addr15 = new Address
            {
                AddressId = 15,
                City = "Austin",
                Street = "10117 Swallow Road",
                PostalCode = "78712",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr15);

            var addr16 = new Address
            {
                AddressId = 16,
                City = "Austin",
                Street = "21344 Marcy Avenue",
                PostalCode = "78786",
                State = StateType.TX,
                Lat = 30.2260199m,
                Lng = -97.7789829m,
            };
            Addresses.Add(addr16);

            var addr17 = new Address
            {
                AddressId = 17,
                City = "Eagle Pass",
                Street = "894 Kim Junction",
                PostalCode = "78852",
                State = StateType.TX,
                Lat = 28.7091433m,
                Lng = -100.4995214m,
            };
            Addresses.Add(addr17);

            var addr18 = new Address
            {
                AddressId = 18,
                City = "Austin",
                Street = "703 Anthes Lane",
                PostalCode = "78729",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr18);

            var addr19 = new Address
            {
                AddressId = 19,
                City = "Georgetown",
                Street = "703 Forest Run Trail",
                PostalCode = "78628",
                State = StateType.TX,
                Lat = 30.6410107m,
                Lng = -97.76340189999999m,
            };
            Addresses.Add(addr19);

            var addr20 = new Address
            {
                AddressId = 20,
                City = "Austin",
                Street = "51 Miller Park",
                PostalCode = "78705",
                State = StateType.TX,
                Lat = 30.2961708m,
                Lng = -97.73895429999999m,
            };
            Addresses.Add(addr20);

            var addr21 = new Address
            {
                AddressId = 21,
                City = "Austin",
                Street = "86086 Ryan Terrace",
                PostalCode = "78704",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr21);

            var addr22 = new Address
            {
                AddressId = 22,
                City = "College Station",
                Street = "97327 Express Avenue",
                PostalCode = "77840",
                State = StateType.TX,
                Lat = 30.627977m,
                Lng = -96.3344068m,
            };
            Addresses.Add(addr22);

            var addr23 = new Address
            {
                AddressId = 23,
                City = "Austin",
                Street = "1 Arrowood Road",
                PostalCode = "78756",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr23);

            var addr24 = new Address
            {
                AddressId = 24,
                City = "Austin",
                Street = "5035 Dayton Court",
                PostalCode = "78746",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr24);

            var addr25 = new Address
            {
                AddressId = 25,
                City = "Austin",
                Street = "90461 Evergreen Place",
                PostalCode = "78756",
                State = StateType.TX,
                Lat = 30.3322876m,
                Lng = -97.7576175m,
            };
            Addresses.Add(addr25);

            var addr26 = new Address
            {
                AddressId = 26,
                City = "Liberty",
                Street = "973 Stephen Alley",
                PostalCode = "77575",
                State = StateType.TX,
                Lat = 30.057993m,
                Lng = -94.7954783m,
            };
            Addresses.Add(addr26);

            var addr27 = new Address
            {
                AddressId = 27,
                City = "San Antonio",
                Street = "80319 Forster Parkway",
                PostalCode = "78203",
                State = StateType.TX,
                Lat = 29.4251905m,
                Lng = -98.4945922m,
            };
            Addresses.Add(addr27);

            var addr28 = new Address
            {
                AddressId = 28,
                City = "New Braunfels",
                Street = "96 Stang Hill",
                PostalCode = "78132",
                State = StateType.TX,
                Lat = 29.702566m,
                Lng = -98.12406349999999m,
            };
            Addresses.Add(addr28);

            var addr29 = new Address
            {
                AddressId = 29,
                City = "New York",
                Street = "23726 Main Crossing",
                PostalCode = "10101",
                State = StateType.NY,
                Lat = 40.7127753m,
                Lng = -74.0059728m,
            };
            Addresses.Add(addr29);

            var addr30 = new Address
            {
                AddressId = 30,
                City = "Lockhart",
                Street = "6299 Moland Alley",
                PostalCode = "78644",
                State = StateType.TX,
                Lat = 29.8849441m,
                Lng = -97.6699996m,
            };
            Addresses.Add(addr30);

            var addr31 = new Address
            {
                AddressId = 31,
                City = "Kingwood",
                Street = "6 Truax Street",
                PostalCode = "77325",
                State = StateType.TX,
                Lat = 30.07m,
                Lng = -95.22m,
            };
            Addresses.Add(addr31);

            var addr32 = new Address
            {
                AddressId = 32,
                City = "Beverly Hills",
                Street = "50883 Heath Park",
                PostalCode = "90210",
                State = StateType.CA,
                Lat = 34.0736204m,
                Lng = -118.4003563m,
            };
            Addresses.Add(addr32);

            var addr33 = new Address
            {
                AddressId = 33,
                City = "Navasota",
                Street = "5 Carberry Point",
                PostalCode = "77868",
                State = StateType.TX,
                Lat = 30.3879845m,
                Lng = -96.0877349m,
            };
            Addresses.Add(addr33);

            var addr34 = new Address
            {
                AddressId = 34,
                City = "Austin",
                Street = "10 Amoth Lane",
                PostalCode = "78712",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr34);

            var addr35 = new Address
            {
                AddressId = 35,
                City = "Austin",
                Street = "1186 Pepper Wood Junction",
                PostalCode = "78712",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr35);

            var addr36 = new Address
            {
                AddressId = 36,
                City = "Schenectady",
                Street = "961 Cody Parkway",
                PostalCode = "12345",
                State = StateType.NY,
                Lat = 42.8142432m,
                Lng = -73.9395687m,
            };
            Addresses.Add(addr36);

            var addr37 = new Address
            {
                AddressId = 37,
                City = "Austin",
                Street = "4921 High Crossing Way",
                PostalCode = "78717",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr37);

            var addr38 = new Address
            {
                AddressId = 38,
                City = "Austin",
                Street = "145 Old Gate Alley",
                PostalCode = "78727",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr38);

            var addr39 = new Address
            {
                AddressId = 39,
                City = "Beaumont",
                Street = "6 Schlimgen Lane",
                PostalCode = "77720",
                State = StateType.TX,
                Lat = 30.080174m,
                Lng = -94.1265562m,
            };
            Addresses.Add(addr39);

            var addr40 = new Address
            {
                AddressId = 40,
                City = "San Marcos",
                Street = "6647 Eastlawn Trail",
                PostalCode = "78667",
                State = StateType.TX,
                Lat = 29.8832749m,
                Lng = -97.9413941m,
            };
            Addresses.Add(addr40);

            var addr41 = new Address
            {
                AddressId = 41,
                City = "Bergheim",
                Street = "7 Mallard Court",
                PostalCode = "78004",
                State = StateType.TX,
                Lat = 29.8274986m,
                Lng = -98.5752874m,
            };
            Addresses.Add(addr41);

            var addr42 = new Address
            {
                AddressId = 42,
                City = "Austin",
                Street = "9517 Hooker Street",
                PostalCode = "78789",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr42);

            var addr43 = new Address
            {
                AddressId = 43,
                City = "Orlando",
                Street = "9 Clemons Terrace",
                PostalCode = "32830",
                State = StateType.FL,
                Lat = 28.5383832m,
                Lng = -81.3789269m,
            };
            Addresses.Add(addr43);

            var addr44 = new Address
            {
                AddressId = 44,
                City = "South Padre Island",
                Street = "37080 Darwin Parkway",
                PostalCode = "78597",
                State = StateType.TX,
                Lat = 26.1118401m,
                Lng = -97.16812569999999m,
            };
            Addresses.Add(addr44);

            var addr45 = new Address
            {
                AddressId = 45,
                City = "Austin",
                Street = "61 Iowa Drive",
                PostalCode = "78744",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr45);

            var addr46 = new Address
            {
                AddressId = 46,
                City = "Canyon Lake",
                Street = "56 Express Trail",
                PostalCode = "78133",
                State = StateType.TX,
                Lat = 29.8781434m,
                Lng = -98.2431747m,
            };
            Addresses.Add(addr46);

            var addr47 = new Address
            {
                AddressId = 47,
                City = "Austin",
                Street = "712 Dayton Terrace",
                PostalCode = "78779",
                State = StateType.TX,
                Lat = 30.3161202m,
                Lng = -97.75497659999999m,
            };
            Addresses.Add(addr47);

            var addr48 = new Address
            {
                AddressId = 48,
                City = "Austin",
                Street = "77 International Drive",
                PostalCode = "78720",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr48);

            var addr49 = new Address
            {
                AddressId = 49,
                City = "Austin",
                Street = "9 Dahle Road",
                PostalCode = "78705",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr49);

            var addr50 = new Address
            {
                AddressId = 50,
                City = "Round Rock",
                Street = "2036 Carpenter Alley",
                PostalCode = "78680",
                State = StateType.TX,
                Lat = 30.5082551m,
                Lng = -97.678896m,
            };
            Addresses.Add(addr50);

            var addr51 = new Address
            {
                AddressId = 51,
                City = "Austin",
                Street = "773 Sullivan Court",
                PostalCode = "78760",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr51);

            var addr52 = new Address
            {
                AddressId = 52,
                City = "Sweet Home",
                Street = "59 Dakota Point",
                PostalCode = "77987",
                State = StateType.TX,
                Lat = 29.3452449m,
                Lng = -97.07165169999999m,
            };
            Addresses.Add(addr52);

            var addr53 = new Address
            {
                AddressId = 53,
                City = "Corpus Christi",
                Street = "20644 Badeau Point",
                PostalCode = "78412",
                State = StateType.TX,
                Lat = 27.687317m,
                Lng = -97.346665m,
            };
            Addresses.Add(addr53);

            var addr54 = new Address
            {
                AddressId = 54,
                City = "Pflugerville",
                Street = "79 Starling Park",
                PostalCode = "78660",
                State = StateType.TX,
                Lat = 30.4332061m,
                Lng = -97.60057859999999m,
            };
            Addresses.Add(addr54);

            var addr55 = new Address
            {
                AddressId = 55,
                City = "Austin",
                Street = "71 Main Circle",
                PostalCode = "78702",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr55);

            var addr56 = new Address
            {
                AddressId = 56,
                City = "Austin",
                Street = "202 Ramsey Junction",
                PostalCode = "78713",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr56);

            var addr57 = new Address
            {
                AddressId = 57,
                City = "Austin",
                Street = "831 Namekagon Avenue",
                PostalCode = "78712",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr57);

            var addr58 = new Address
            {
                AddressId = 58,
                City = "Austin",
                Street = "6587 Debs Junction",
                PostalCode = "78786",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr58);

            var addr59 = new Address
            {
                AddressId = 59,
                City = "San Antonio",
                Street = "37 Ohio Pass",
                PostalCode = "78279",
                State = StateType.TX,
                Lat = 29.4251905m,
                Lng = -98.4945922m,
            };
            Addresses.Add(addr59);

            var addr60 = new Address
            {
                AddressId = 60,
                City = "Navasota",
                Street = "3 Bartillon Junction",
                PostalCode = "77868",
                State = StateType.TX,
                Lat = 30.3879845m,
                Lng = -96.0877349m,
            };
            Addresses.Add(addr60);

            var addr61 = new Address
            {
                AddressId = 61,
                City = "Boston",
                Street = "59699 Hovde Terrace",
                PostalCode = "02114",
                State = StateType.MA,
                Lat = 42.3600825m,
                Lng = -71.0588801m,
            };
            Addresses.Add(addr61);

            var addr62 = new Address
            {
                AddressId = 62,
                City = "Marble Falls",
                Street = "89 Jenna Terrace",
                PostalCode = "78654",
                State = StateType.TX,
                Lat = 30.5782297m,
                Lng = -98.2729184m,
            };
            Addresses.Add(addr62);

            var addr63 = new Address
            {
                AddressId = 63,
                City = "Austin",
                Street = "4 Main Place",
                PostalCode = "78730",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr63);

            var addr64 = new Address
            {
                AddressId = 64,
                City = "Austin",
                Street = "95 Longview Point",
                PostalCode = "78712",
                State = StateType.TX,
                Lat = 30.267153m,
                Lng = -97.7430608m,
            };
            Addresses.Add(addr64);

            var addr65 = new Address
            {
                AddressId = 65,
                City = "Orlando",
                Street = "400 South Orange Avenue",
                PostalCode = "32801",
                State = StateType.FL,
                Lat = 28.5376214m,
                Lng = -81.3796806m,
            };
            Addresses.Add(addr65);

            var addr66 = new Address
            {
                AddressId = 66,
                City = "Houston",
                Street = "901 Bagby Sreet",
                PostalCode = "77002",
                State = StateType.TX,
                Lat = 29.760271m,
                Lng = -95.3693347m,
            };
            Addresses.Add(addr66);

            var addr67 = new Address
            {
                AddressId = 67,
                City = "Houston",
                Street = "1301 Fannin Street",
                PostalCode = "77002",
                State = StateType.TX,
                Lat = 29.7533742m,
                Lng = -95.3657403m,
            };
            Addresses.Add(addr67);

            var addr68 = new Address
            {
                AddressId = 68,
                City = "Dallas",
                Street = "5205 North O'Connor Boulevard",
                PostalCode = "75039",
                State = StateType.TX,
                Lat = 32.8706424m,
                Lng = -96.93958149999999m,
            };
            Addresses.Add(addr68);

            var addr69 = new Address
            {
                AddressId = 69,
                City = "Austin",
                Street = "10414 McKalla Place",
                PostalCode = "78758",
                State = StateType.TX,
                Lat = 30.387725m,
                Lng = -97.71941299999999m,
            };
            Addresses.Add(addr69);

            var addr70 = new Address
            {
                AddressId = 70,
                City = "Los Angeles",
                Street = "1111 South Figueroa Street",
                PostalCode = "90015",
                State = StateType.CA,
                Lat = 34.0432309m,
                Lng = -118.2671588m,
            };
            Addresses.Add(addr70);

            var addr71 = new Address
            {
                AddressId = 71,
                City = "Chicago",
                Street = "1901 West Madison Street",
                PostalCode = "60612",
                State = StateType.IL,
                Lat = 41.8806277m,
                Lng = -87.6740485m,
            };
            Addresses.Add(addr71);

            var addr72 = new Address
            {
                AddressId = 72,
                City = "Richmond",
                Street = "410 Westhampton Way",
                PostalCode = "23173",
                State = StateType.VA,
                Lat = 37.5751669m,
                Lng = -77.5407146m,
            };
            Addresses.Add(addr72);

            var addr73 = new Address
            {
                AddressId = 73,
                City = "Plano",
                Street = "2200 Independence Parkway",
                PostalCode = "75075",
                State = StateType.TX,
                Lat = 33.0287381m,
                Lng = -96.75190839999999m,
            };
            Addresses.Add(addr73);

            var addr74 = new Address
            {
                AddressId = 74,
                City = "Dallas",
                Street = "2200 Ross Avenue",
                PostalCode = "75201",
                State = StateType.TX,
                Lat = 32.7876958m,
                Lng = -96.797163m,
            };
            Addresses.Add(addr74);

            var addr75 = new Address
            {
                AddressId = 75,
                City = "New York",
                Street = "1335 6th Avenue",
                PostalCode = "10019",
                State = StateType.NY,
                Lat = 40.7625263m,
                Lng = -73.97987909999999m,
            };
            Addresses.Add(addr75);

            var addr76 = new Address
            {
                AddressId = 76,
                City = "Austin",
                Street = "2001 Robert Dedman Drive",
                PostalCode = "78712",
                State = StateType.TX,
                Lat = 30.2814504m,
                Lng = -97.73082409999999m,
            };
            Addresses.Add(addr76);

            var addr77 = new Address
            {
                AddressId = 77,
                City = "Houston",
                Street = "8900 Bellaire Boulevard",
                PostalCode = "77036",
                State = StateType.TX,
                Lat = 29.7086716m,
                Lng = -95.5412771m,
            };
            Addresses.Add(addr77);

            var addr78 = new Address
            {
                AddressId = 78,
                City = "Dallas",
                Street = "1717 McKinney Avenue",
                PostalCode = "75202",
                State = StateType.TX,
                Lat = 32.7885264m,
                Lng = -96.8044412m,
            };
            Addresses.Add(addr78);

            var addr79 = new Address
            {
                AddressId = 79,
                City = "Austin",
                Street = "2825 Hancock Drive",
                PostalCode = "78731",
                State = StateType.TX,
                Lat = 30.3277549m,
                Lng = -97.75071009999999m,
            };
            Addresses.Add(addr79);

            var addr80 = new Address
            {
                AddressId = 80,
                City = "Fort Worth",
                Street = "1911 Montgomery Street",
                PostalCode = "76107",
                State = StateType.TX,
                Lat = 32.7411451m,
                Lng = -97.3683365m,
            };
            Addresses.Add(addr80);

            var addr81 = new Address
            {
                AddressId = 81,
                City = "Austin",
                Street = "28 Holy Shizay Sheist Ln",
                PostalCode = "78705",
                State = StateType.TX,
                Lat = 30.284996m,
                Lng = -97.7447962m,
            };
            Addresses.Add(addr81);

            builder.Entity<Address>().HasData(Addresses);

            // Seed Companies
            List<Company> Companies = new List<Company>();

            var comp1 = new Company
            {
                AddressId = 1,
                CompanyId = 1,
                CompanyName = "Accenture",
                CompanyEmail = "accenture@example.com",
                CompanyDescription = "Accenture is a global management consulting, technology services and outsourcing company.",
                WebsiteUrl = "https://www.accenture.com/"
            };
            Companies.Add(comp1);

            var comp2 = new Company
            {
                AddressId = 2,
                CompanyId = 2,
                CompanyName = "Shell",
                CompanyEmail = "shell@example.com",
                CompanyDescription = "Shell Oil Company, including its consolidated companies and its share in equity companies, is one of America's leading oild and natural gas producers, natural gas marketers, gasoline marketers and petrochemical manufacturers.",
                WebsiteUrl = "https://www.shell.com/"
            };
            Companies.Add(comp2);

            var comp3 = new Company
            {
                AddressId = 3,
                CompanyId = 3,
                CompanyName = "Deloitte",
                CompanyEmail = "deloitte@example.com",
                CompanyDescription = "Deloitte is one of the leading professional services organizations in the United States specializing in audit, tax, consulting, and financial advisory services with clients in more than 20 industries.",
                WebsiteUrl = "https://www.deloitte.com/"
            };
            Companies.Add(comp3);

            var comp4 = new Company
            {
                AddressId = 4,
                CompanyId = 4,
                CompanyName = "Capital One",
                CompanyEmail = "capitalone@example.com",
                CompanyDescription = "Capital One offers a broad spectrum of financial products and services to consumers, small businesses and commercial clients.",
                WebsiteUrl = "https://www.capitalone.com/"
            };
            Companies.Add(comp4);

            var comp5 = new Company
            {
                AddressId = 5,
                CompanyId = 5,
                CompanyName = "Texas Instruments",
                CompanyEmail = "texasinstruments@example.com",
                CompanyDescription = "TI is one of the world’s largest global leaders in analog and digital semiconductor design and manufacturing",
                WebsiteUrl = "https://www.ti.com/"
            };
            Companies.Add(comp5);

            var comp6 = new Company
            {
                AddressId = 6,
                CompanyId = 6,
                CompanyName = "Hilton Worldwide",
                CompanyEmail = "hiltonworldwide@example.com",
                CompanyDescription = "Hilton Worldwide offers business and leisure travelers the finest in accommodations, service, amenities and value.",
                WebsiteUrl = "https://www.hilton.com/"
            };
            Companies.Add(comp6);

            var comp7 = new Company
            {
                AddressId = 7,
                CompanyId = 7,
                CompanyName = "Aon",
                CompanyEmail = "aon@example.com",
                CompanyDescription = "Aon is the leading global provider of risk management, insurance and reinsurance brokerage, and human resources solutions and outsourcing services.",
                WebsiteUrl = "https://www.aon.com/home/index"
            };
            Companies.Add(comp7);

            var comp8 = new Company
            {
                AddressId = 8,
                CompanyId = 8,
                CompanyName = "Adlucent",
                CompanyEmail = "adlucent@example.com",
                CompanyDescription = "Adlucent is a technology and analytics company specializing in selling products through the Internet for online retail clients.",
                WebsiteUrl = "https://www.adlucent.com/"
            };
            Companies.Add(comp8);

            var comp9 = new Company
            {
                AddressId = 9,
                CompanyId = 9,
                CompanyName = "Stream Realty Partners",
                CompanyEmail = "streamrealtypartners@example.com",
                CompanyDescription = "Stream Realty Partners, L.P. (Stream) is a national, commercial real estate firm with locations across the country.",
                WebsiteUrl = "https://streamrealty.com/"
            };
            Companies.Add(comp9);

            var comp10 = new Company
            {
                AddressId = 10,
                CompanyId = 10,
                CompanyName = "Microsoft",
                CompanyEmail = "microsoft@example.com",
                CompanyDescription = "Microsoft is the worldwide leader in software, services and solutions that help people and businesses realize their full potential.",
                WebsiteUrl = "https://www.microsoft.com/"
            };
            Companies.Add(comp10);

            var comp11 = new Company
            {
                AddressId = 11,
                CompanyId = 11,
                CompanyName = "Academy Sports & Outdoors",
                CompanyEmail = "academysports@example.com",
                CompanyDescription = "Academy Sports is intensely focused on being a leader in the sporting goods, outdoor and lifestyle retail arena",
                WebsiteUrl = "https://www.academy.com/"
            };
            Companies.Add(comp11);

            var comp12 = new Company
            {
                AddressId = 12,
                CompanyId = 12,
                CompanyName = "United Airlines",
                CompanyEmail = "unitedairlines@example.com",
                CompanyDescription = "United Airlines has the most modern and fuel-efficient fleet (when adjusted for cabin size), and the best new aircraft order book, among U.S. network carriers",
                WebsiteUrl = "https://www.united.com/"
            };
            Companies.Add(comp12);

            var comp13 = new Company
            {
                AddressId = 13,
                CompanyId = 13,
                CompanyName = "Target",
                CompanyEmail = "target@example.com",
                CompanyDescription = "Target is a leading retailer",
                WebsiteUrl = "https://www.target.com/"
            };
            Companies.Add(comp13);

            builder.Entity<Company>().HasData(Companies);

            // Add Company Industries
            List<CompanyIndustry> CompanyIndustries = new List<CompanyIndustry>();

            var CompanyIndustry1 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Accenture").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.Consulting).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry1);

            var CompanyIndustry2 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Accenture").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.Technology).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry2);

            var CompanyIndustry3 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Shell").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.Energy).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry3);

            var CompanyIndustry4 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Shell").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.Chemicals).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry4);

            var CompanyIndustry5 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Deloitte").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.Accounting).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry5);

            var CompanyIndustry6 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Deloitte").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.Consulting).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry6);

            var CompanyIndustry7 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Deloitte").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.Technology).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry7);

            var CompanyIndustry8 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Capital One").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.FinancialServices).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry8);

            var CompanyIndustry9 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Texas Instruments").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.Manufacturing).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry9);

            var CompanyIndustry10 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Hilton Worldwide").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.Hospitality).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry10);

            var CompanyIndustry11 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Aon").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.Insurance).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry11);

            var CompanyIndustry12 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Aon").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.Consulting).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry12);

            var CompanyIndustry13 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Adlucent").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.Marketing).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry13);

            var CompanyIndustry14 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Adlucent").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.Technology).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry14);

            var CompanyIndustry15 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Stream Realty Partners").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.RealEstate).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry15);

            var CompanyIndustry16 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Microsoft").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.Technology).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry16);

            var CompanyIndustry17 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Academy Sports & Outdoors").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.Retail).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry17);

            var CompanyIndustry18 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "United Airlines").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.Transportation).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry18);

            var CompanyIndustry19 = new CompanyIndustry
            {
                CompanyId = Companies.First(c => c.CompanyName == "Target").CompanyId,
                IndustryId = Industries.First(i => i.IndustryType == IndustryTypes.Retail).IndustryId
            };
            CompanyIndustries.Add(CompanyIndustry19);

            builder.Entity<CompanyIndustry>().HasData(CompanyIndustries);

            // Seed CSOs
            var CSO1 = new AppUser
            {
                UserName = "ra@aoo.com",
                Email = "ra@aoo.com",
                FirstName = "Allen",
                LastName = "Rogers",
            };
            CSO1.NormalizedUserName = CSO1.UserName.ToUpper();
            CSO1.NormalizedEmail = CSO1.Email.ToUpper();
            CSO1.PasswordHash = passwordHasher.HashPassword(CSO1, "3wCynC");

            var CSO2 = new AppUser
            {
                UserName = "captain@enterprise.net",
                Email = "captain@enterprise.net",
                FirstName = "Jean Luc",
                LastName = "Picard",
            };
            CSO2.NormalizedUserName = CSO2.UserName.ToUpper();
            CSO2.NormalizedEmail = CSO2.Email.ToUpper();
            CSO2.PasswordHash = passwordHasher.HashPassword(CSO2, "Pbon0r");

            var CSO3 = new AppUser
            {
                UserName = "slayer@onegirl.net",
                Email = "slayer@onegirl.net",
                FirstName = "Buffy",
                LastName = "Summers",
            };
            CSO3.NormalizedUserName = CSO3.UserName.ToUpper();
            CSO3.NormalizedEmail = CSO3.Email.ToUpper();
            CSO3.PasswordHash = passwordHasher.HashPassword(CSO3, "jW5fPP");

            var CSO4 = new AppUser
            {
                UserName = "liz@ggmail.com",
                Email = "liz@ggmail.com",
                FirstName = "Elizabeth",
                LastName = "Markham",
            };
            CSO4.NormalizedUserName = CSO4.UserName.ToUpper();
            CSO4.NormalizedEmail = CSO4.Email.ToUpper();
            CSO4.PasswordHash = passwordHasher.HashPassword(CSO4, "0QyilL");

            var CSO5 = new AppUser
            {
                UserName = "twin@deservedbetter.com",
                Email = "twin@deservedbetter.com",
                FirstName = "Fred",
                LastName = "Weasley",
            };
            CSO5.NormalizedUserName = CSO5.UserName.ToUpper();
            CSO5.NormalizedEmail = CSO5.Email.ToUpper();
            CSO5.PasswordHash = passwordHasher.HashPassword(CSO5, "atLm6W");

            List<AppUser> CSOs = new List<AppUser>() {
                CSO1,
                CSO2,
                CSO3,
                CSO4,
                CSO5
            };

            builder.Entity<AppUser>().HasData(CSOs);

            // Seed CSORoles
            List<IdentityUserRole<string>> CSORoles = new List<IdentityUserRole<string>>();
            var CSORoleId = Roles.First(q => q.Name == "Admin").Id;

            foreach (var CSO in CSOs)
            {
                CSORoles.Add(new IdentityUserRole<string>
                {
                    UserId = CSO.Id,
                    RoleId = CSORoleId
                });
            }

            builder.Entity<IdentityUserRole<string>>().HasData(CSORoles);


            // Seed Recruiters
            List<AppUser> Recruiters = new List<AppUser>();

            var Rec1 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Accenture").CompanyId,
                UserName = "michelle@example.com",
                Email = "michelle@example.com",
                FirstName = "Michelle",
                LastName = "Banks"
            };
            Rec1.NormalizedUserName = Rec1.UserName.ToUpper();
            Rec1.NormalizedEmail = Rec1.Email.ToUpper();
            Rec1.PasswordHash = passwordHasher.HashPassword(Rec1, "jVb0Z6");
            Recruiters.Add(Rec1);

            var Rec2 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Accenture").CompanyId,
                UserName = "toddy@aool.com",
                Email = "toddy@aool.com",
                FirstName = "Todd",
                LastName = "Jacobs"
            };
            Rec2.NormalizedUserName = Rec2.UserName.ToUpper();
            Rec2.NormalizedEmail = Rec2.Email.ToUpper();
            Rec2.PasswordHash = passwordHasher.HashPassword(Rec2, "1PnrBV");
            Recruiters.Add(Rec2);

            var Rec3 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Shell").CompanyId,
                UserName = "elowe@netscrape.net",
                Email = "elowe@netscrape.net",
                FirstName = "Ernest",
                LastName = "Lowe"
            };
            Rec3.NormalizedUserName = Rec3.UserName.ToUpper();
            Rec3.NormalizedEmail = Rec3.Email.ToUpper();
            Rec3.PasswordHash = passwordHasher.HashPassword(Rec3, "v3n5AV");
            Recruiters.Add(Rec3);

            var Rec4 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Deloitte").CompanyId,
                UserName = "mclarence@aool.com",
                Email = "mclarence@aool.com",
                FirstName = "Clarence",
                LastName = "Martin"
            };
            Rec4.NormalizedUserName = Rec4.UserName.ToUpper();
            Rec4.NormalizedEmail = Rec4.Email.ToUpper();
            Rec4.PasswordHash = passwordHasher.HashPassword(Rec4, "zBLq3S");
            Recruiters.Add(Rec4);

            var Rec5 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Deloitte").CompanyId,
                UserName = "nelson.Kelly@aool.com",
                Email = "nelson.Kelly@aool.com",
                FirstName = "Kelly",
                LastName = "Nelson"
            };
            Rec5.NormalizedUserName = Rec5.UserName.ToUpper();
            Rec5.NormalizedEmail = Rec5.Email.ToUpper();
            Rec5.PasswordHash = passwordHasher.HashPassword(Rec5, "FSb8rA");
            Recruiters.Add(Rec5);

            var Rec6 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Deloitte").CompanyId,
                UserName = "megrhodes@freezing.co.uk",
                Email = "megrhodes@freezing.co.uk",
                FirstName = "Megan",
                LastName = "Rhodes"
            };
            Rec6.NormalizedUserName = Rec6.UserName.ToUpper();
            Rec6.NormalizedEmail = Rec6.Email.ToUpper();
            Rec6.PasswordHash = passwordHasher.HashPassword(Rec6, "1xVfHp");
            Recruiters.Add(Rec6);

            var Rec7 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Texas Instruments").CompanyId,
                UserName = "sheff44@ggmail.com",
                Email = "sheff44@ggmail.com",
                FirstName = "Martin",
                LastName = "Sheffield"
            };
            Rec7.NormalizedUserName = Rec7.UserName.ToUpper();
            Rec7.NormalizedEmail = Rec7.Email.ToUpper();
            Rec7.PasswordHash = passwordHasher.HashPassword(Rec7, "4XKLsd");
            Recruiters.Add(Rec7);

            var Rec8 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Texas Instruments").CompanyId,
                UserName = "peterstump@hootmail.com",
                Email = "peterstump@hootmail.com",
                FirstName = "Peter",
                LastName = "Stump"
            };
            Rec8.NormalizedUserName = Rec8.UserName.ToUpper();
            Rec8.NormalizedEmail = Rec8.Email.ToUpper();
            Rec8.PasswordHash = passwordHasher.HashPassword(Rec8, "1XdmSV");
            Recruiters.Add(Rec8);

            var Rec9 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Hilton Worldwide").CompanyId,
                UserName = "yhuik9.Taylor@aool.com",
                Email = "yhuik9.Taylor@aool.com",
                FirstName = "Rachel",
                LastName = "Taylor"
            };
            Rec9.NormalizedUserName = Rec9.UserName.ToUpper();
            Rec9.NormalizedEmail = Rec9.Email.ToUpper();
            Rec9.PasswordHash = passwordHasher.HashPassword(Rec9, "9yhFS3");
            Recruiters.Add(Rec9);

            var Rec10 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Aon").CompanyId,
                UserName = "tuck33@ggmail.com",
                Email = "tuck33@ggmail.com",
                FirstName = "Clent",
                LastName = "Tucker"
            };
            Rec10.NormalizedUserName = Rec10.UserName.ToUpper();
            Rec10.NormalizedEmail = Rec10.Email.ToUpper();
            Rec10.PasswordHash = passwordHasher.HashPassword(Rec10, "I6BgsS");
            Recruiters.Add(Rec10);

            var Rec11 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Adlucent").CompanyId,
                UserName = "taylordjay@aool.com",
                Email = "taylordjay@aool.com",
                FirstName = "Allison",
                LastName = "Taylor"
            };
            Rec11.NormalizedUserName = Rec11.UserName.ToUpper();
            Rec11.NormalizedEmail = Rec11.Email.ToUpper();
            Rec11.PasswordHash = passwordHasher.HashPassword(Rec11, "Vjb1wI");
            Recruiters.Add(Rec11);

            var Rec12 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Stream Realty Partners").CompanyId,
                UserName = "jojoe@ggmail.com",
                Email = "jojoe@ggmail.com",
                FirstName = "Joe",
                LastName = "Nguyen"
            };
            Rec12.NormalizedUserName = Rec12.UserName.ToUpper();
            Rec12.NormalizedEmail = Rec12.Email.ToUpper();
            Rec12.PasswordHash = passwordHasher.HashPassword(Rec12, "xI8Brg");
            Recruiters.Add(Rec12);

            var Rec13 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Microsoft").CompanyId,
                UserName = "hicks43@ggmail.com",
                Email = "hicks43@ggmail.com",
                FirstName = "Anthony",
                LastName = "Hicks"
            };
            Rec13.NormalizedUserName = Rec13.UserName.ToUpper();
            Rec13.NormalizedEmail = Rec13.Email.ToUpper();
            Rec13.PasswordHash = passwordHasher.HashPassword(Rec13, "s33WOz");
            Recruiters.Add(Rec13);

            var Rec14 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Microsoft").CompanyId,
                UserName = "orielly@foxnets.com",
                Email = "orielly@foxnets.com",
                FirstName = "Bill",
                LastName = "O'Reilly"
            };
            Rec14.NormalizedUserName = Rec14.UserName.ToUpper();
            Rec14.NormalizedEmail = Rec14.Email.ToUpper();
            Rec14.PasswordHash = passwordHasher.HashPassword(Rec14, "pS2OJh");
            Recruiters.Add(Rec14);

            var Rec15 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Microsoft").CompanyId,
                UserName = "louielouie@aool.com",
                Email = "louielouie@aool.com",
                FirstName = "Louis",
                LastName = "Winthorpe"
            };
            Rec15.NormalizedUserName = Rec15.UserName.ToUpper();
            Rec15.NormalizedEmail = Rec15.Email.ToUpper();
            Rec15.PasswordHash = passwordHasher.HashPassword(Rec15, "fq7yDw");
            Recruiters.Add(Rec15);

            var Rec16 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Capital One").CompanyId,
                UserName = "smartinmartin.Martin@aool.com",
                Email = "smartinmartin.Martin@aool.com",
                FirstName = "Gregory",
                LastName = "Martinez"
            };
            Rec16.NormalizedUserName = Rec16.UserName.ToUpper();
            Rec16.NormalizedEmail = Rec16.Email.ToUpper();
            Rec16.PasswordHash = passwordHasher.HashPassword(Rec16, "1rKkMW");
            Recruiters.Add(Rec16);

            var Rec17 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Capital One").CompanyId,
                UserName = "or@aool.com",
                Email = "or@aool.com",
                FirstName = "Anka",
                LastName = "Radkovich"
            };
            Rec17.NormalizedUserName = Rec17.UserName.ToUpper();
            Rec17.NormalizedEmail = Rec17.Email.ToUpper();
            Rec17.PasswordHash = passwordHasher.HashPassword(Rec17, "8K0cAh");
            Recruiters.Add(Rec17);

            var Rec18 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "United Airlines").CompanyId,
                UserName = "tanner@ggmail.com",
                Email = "tanner@ggmail.com",
                FirstName = "Jeremy",
                LastName = "Tanner"
            };
            Rec18.NormalizedUserName = Rec18.UserName.ToUpper();
            Rec18.NormalizedEmail = Rec18.Email.ToUpper();
            Rec18.PasswordHash = passwordHasher.HashPassword(Rec18, "w9wPff");
            Recruiters.Add(Rec18);

            var Rec19 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Academy Sports & Outdoors").CompanyId,
                UserName = "tee_frank@hootmail.com",
                Email = "tee_frank@hootmail.com",
                FirstName = "Frank",
                LastName = "Tee"
            };
            Rec19.NormalizedUserName = Rec19.UserName.ToUpper();
            Rec19.NormalizedEmail = Rec19.Email.ToUpper();
            Rec19.PasswordHash = passwordHasher.HashPassword(Rec19, "1EIwbx");
            Recruiters.Add(Rec19);

            var Rec20 = new AppUser
            {
                CompanyId = Companies.FirstOrDefault(c => c.CompanyName == "Target").CompanyId,
                UserName = "target_spot@example.com",
                Email = "target_spot@example.com",
                FirstName = "Spot",
                LastName = "Dog"
            };
            Rec20.NormalizedUserName = Rec20.UserName.ToUpper();
            Rec20.NormalizedEmail = Rec20.Email.ToUpper();
            Rec20.PasswordHash = passwordHasher.HashPassword(Rec20, "spotthedog");
            Recruiters.Add(Rec20);

            builder.Entity<AppUser>().HasData(Recruiters);

            // Seed Recruiter Roles
            List<IdentityUserRole<string>> RecruiterRoles = new List<IdentityUserRole<string>>();
            var RecruiterRoleId = Roles.First(q => q.Name == "Recruiter").Id;

            foreach (var Recruiter in Recruiters)
            {
                RecruiterRoles.Add(new IdentityUserRole<string>
                {
                    UserId = Recruiter.Id,
                    RoleId = RecruiterRoleId
                });
            }

            builder.Entity<IdentityUserRole<string>>().HasData(RecruiterRoles);

            // Seed Students
            List<AppUser> Students = new List<AppUser>();


            var Student1 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.White,
                AddressId = 14,
                UserName = "cbaker@example.com",
                Email = "cbaker@example.com",
                FirstName = "Christopher",
                LastName = "Baker",
                GPA = 3.91m,
                DateOfBirth = new DateTime(2001, 8, 2),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student1.NormalizedUserName = Student1.UserName.ToUpper();
            Student1.NormalizedEmail = Student1.Email.ToUpper();
            Student1.PasswordHash = passwordHasher.HashPassword(Student1, "bookworm");
            Students.Add(Student1);

            var Student2 = new AppUser
            {
                Gender = Gender.F,
                Ethnicity = Ethnicity.BlackOrAfricanAmerican,
                AddressId = 15,
                UserName = "banker@longhorn.net",
                Email = "banker@longhorn.net",
                FirstName = "Michelle",
                LastName = "Banks",
                GPA = 3.52m,
                DateOfBirth = new DateTime(2000, 11, 18),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student2.NormalizedUserName = Student2.UserName.ToUpper();
            Student2.NormalizedEmail = Student2.Email.ToUpper();
            Student2.PasswordHash = passwordHasher.HashPassword(Student2, "aclfest2017");
            Students.Add(Student2);

            var Student3 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.White,
                AddressId = 16,
                UserName = "franco@example.com",
                Email = "franco@example.com",
                FirstName = "Franco",
                LastName = "Broccolo",
                GPA = 3.20m,
                DateOfBirth = new DateTime(2002, 5, 2),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student3.NormalizedUserName = Student3.UserName.ToUpper();
            Student3.NormalizedEmail = Student3.Email.ToUpper();
            Student3.PasswordHash = passwordHasher.HashPassword(Student3, "aggies");
            Students.Add(Student3);

            var Student4 = new AppUser
            {
                Gender = Gender.F,
                Ethnicity = Ethnicity.Asian,
                AddressId = 17,
                UserName = "wchang@example.com",
                Email = "wchang@example.com",
                FirstName = "Wendy",
                LastName = "Chang",
                GPA = 3.56m,
                DateOfBirth = new DateTime(2001, 8, 20),
                GraduationDate = new DateTime(2025, 5, 6),
                PositionType = PositionType.I
            };
            Student4.NormalizedUserName = Student4.UserName.ToUpper();
            Student4.NormalizedEmail = Student4.Email.ToUpper();
            Student4.PasswordHash = passwordHasher.HashPassword(Student4, "alaskaboy");
            Students.Add(Student4);

            var Student5 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.Asian,
                AddressId = 18,
                UserName = "limchou@gogle.com",
                Email = "limchou@gogle.com",
                FirstName = "Lim",
                LastName = "Chou",
                GPA = 2.63m,
                DateOfBirth = new DateTime(2003, 4, 6),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student5.NormalizedUserName = Student5.UserName.ToUpper();
            Student5.NormalizedEmail = Student5.Email.ToUpper();
            Student5.PasswordHash = passwordHasher.HashPassword(Student5, "allyrally");
            Students.Add(Student5);

            var Student6 = new AppUser
            {
                Gender = Gender.F,
                Ethnicity = Ethnicity.White,
                AddressId = 19,
                UserName = "shdixon@aoll.com",
                Email = "shdixon@aoll.com",
                FirstName = "Shan",
                LastName = "Dixon",
                GPA = 3.62m,
                DateOfBirth = new DateTime(2002, 10, 21),
                GraduationDate = new DateTime(2026, 5, 6),
                PositionType = PositionType.I
            };
            Student6.NormalizedUserName = Student6.UserName.ToUpper();
            Student6.NormalizedEmail = Student6.Email.ToUpper();
            Student6.PasswordHash = passwordHasher.HashPassword(Student6, "Anchorage");
            Students.Add(Student6);

            var Student7 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.White,
                AddressId = 20,
                UserName = "j.b.evans@aheca.org",
                Email = "j.b.evans@aheca.org",
                FirstName = "Jim Bob",
                LastName = "Evans",
                GPA = 2.64m,
                DateOfBirth = new DateTime(2001, 10, 8),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student7.NormalizedUserName = Student7.UserName.ToUpper();
            Student7.NormalizedEmail = Student7.Email.ToUpper();
            Student7.PasswordHash = passwordHasher.HashPassword(Student7, "billyboy");
            Students.Add(Student7);

            var Student8 = new AppUser
            {
                Gender = Gender.F,
                Ethnicity = Ethnicity.White,
                AddressId = 21,
                UserName = "feeley@penguin.org",
                Email = "feeley@penguin.org",
                FirstName = "Lou Ann",
                LastName = "Feeley",
                GPA = 3.66m,
                DateOfBirth = new DateTime(2003, 6, 19),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student8.NormalizedUserName = Student8.UserName.ToUpper();
            Student8.NormalizedEmail = Student8.Email.ToUpper();
            Student8.PasswordHash = passwordHasher.HashPassword(Student8, "bunnyhop");
            Students.Add(Student8);

            var Student9 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.NativeHawaiianandOtherPacificIslander,
                AddressId = 22,
                UserName = "tfreeley@minnetonka.ci.us",
                Email = "tfreeley@minnetonka.ci.us",
                FirstName = "Tesa",
                LastName = "Freeley",
                GPA = 3.98m,
                DateOfBirth = new DateTime(1996, 9, 12),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.I
            };
            Student9.NormalizedUserName = Student9.UserName.ToUpper();
            Student9.NormalizedEmail = Student9.Email.ToUpper();
            Student9.PasswordHash = passwordHasher.HashPassword(Student9, "dustydusty");
            Students.Add(Student9);

            var Student10 = new AppUser
            {
                Gender = Gender.F,
                Ethnicity = Ethnicity.Hispanic,
                AddressId = 23,
                UserName = "mgarcia@gogle.com",
                Email = "mgarcia@gogle.com",
                FirstName = "Margaret",
                LastName = "Garcia",
                GPA = 3.22m,
                DateOfBirth = new DateTime(2002, 6, 17),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student10.NormalizedUserName = Student10.UserName.ToUpper();
            Student10.NormalizedEmail = Student10.Email.ToUpper();
            Student10.PasswordHash = passwordHasher.HashPassword(Student10, "gowest");
            Students.Add(Student10);

            var Student11 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.BlackOrAfricanAmerican,
                AddressId = 24,
                UserName = "chaley@thug.com",
                Email = "chaley@thug.com",
                FirstName = "Charles",
                LastName = "Haley",
                GPA = 3.78m,
                DateOfBirth = new DateTime(1998, 5, 15),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student11.NormalizedUserName = Student11.UserName.ToUpper();
            Student11.NormalizedEmail = Student11.Email.ToUpper();
            Student11.PasswordHash = passwordHasher.HashPassword(Student11, "hampton1");
            Students.Add(Student11);

            var Student12 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.BlackOrAfricanAmerican,
                AddressId = 25,
                UserName = "jeffh@sonic.com",
                Email = "jeffh@sonic.com",
                FirstName = "Jeffrey",
                LastName = "Hampton",
                GPA = 3.66m,
                DateOfBirth = new DateTime(2003, 4, 8),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student12.NormalizedUserName = Student12.UserName.ToUpper();
            Student12.NormalizedEmail = Student12.Email.ToUpper();
            Student12.PasswordHash = passwordHasher.HashPassword(Student12, "hickhickup");
            Students.Add(Student12);

            var Student13 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.White,
                AddressId = 26,
                UserName = "wjhearniii@umich.org",
                Email = "wjhearniii@umich.org",
                FirstName = "John",
                LastName = "Hearn",
                GPA = 3.46m,
                DateOfBirth = new DateTime(2000, 9, 15),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student13.NormalizedUserName = Student13.UserName.ToUpper();
            Student13.NormalizedEmail = Student13.Email.ToUpper();
            Student13.PasswordHash = passwordHasher.HashPassword(Student13, "ingram2015");
            Students.Add(Student13);

            var Student14 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.TwoOrMoreRaces,
                AddressId = 27,
                UserName = "ahick@yaho.com",
                Email = "ahick@yaho.com",
                FirstName = "Anthony",
                LastName = "Hicks",
                GPA = 3.12m,
                DateOfBirth = new DateTime(2003, 5, 7),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student14.NormalizedUserName = Student14.UserName.ToUpper();
            Student14.NormalizedEmail = Student14.Email.ToUpper();
            Student14.PasswordHash = passwordHasher.HashPassword(Student14, "jhearn22");
            Students.Add(Student14);

            var Student15 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.BlackOrAfricanAmerican,
                AddressId = 28,
                UserName = "ingram@jack.com",
                Email = "ingram@jack.com",
                FirstName = "Brad",
                LastName = "Ingram",
                GPA = 3.72m,
                DateOfBirth = new DateTime(2001, 2, 6),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student15.NormalizedUserName = Student15.UserName.ToUpper();
            Student15.NormalizedEmail = Student15.Email.ToUpper();
            Student15.PasswordHash = passwordHasher.HashPassword(Student15, "joejoejoe");
            Students.Add(Student15);

            var Student16 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.Hispanic,
                AddressId = 29,
                UserName = "toddj@yourmom.com",
                Email = "toddj@yourmom.com",
                FirstName = "Todd",
                LastName = "Jacobs",
                GPA = 2.64m,
                DateOfBirth = new DateTime(2001, 8, 29),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student16.NormalizedUserName = Student16.UserName.ToUpper();
            Student16.NormalizedEmail = Student16.Email.ToUpper();
            Student16.PasswordHash = passwordHasher.HashPassword(Student16, "jrod2017");
            Students.Add(Student16);

            var Student17 = new AppUser
            {
                Gender = Gender.F,
                Ethnicity = Ethnicity.BlackOrAfricanAmerican,
                AddressId = 30,
                UserName = "thequeen@aska.net",
                Email = "thequeen@aska.net",
                FirstName = "Victoria",
                LastName = "Lawrence",
                GPA = 3.72m,
                DateOfBirth = new DateTime(2001, 1, 29),
                GraduationDate = new DateTime(2025, 5, 6),
                PositionType = PositionType.I
            };
            Student17.NormalizedUserName = Student17.UserName.ToUpper();
            Student17.NormalizedEmail = Student17.Email.ToUpper();
            Student17.PasswordHash = passwordHasher.HashPassword(Student17, "longhorns");
            Students.Add(Student17);

            var Student18 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.Hispanic,
                AddressId = 31,
                UserName = "linebacker@gogle.com",
                Email = "linebacker@gogle.com",
                FirstName = "Erik",
                LastName = "Lineback",
                GPA = 3.15m,
                DateOfBirth = new DateTime(2004, 5, 21),
                GraduationDate = new DateTime(2026, 5, 6),
                PositionType = PositionType.I
            };
            Student18.NormalizedUserName = Student18.UserName.ToUpper();
            Student18.NormalizedEmail = Student18.Email.ToUpper();
            Student18.PasswordHash = passwordHasher.HashPassword(Student18, "louielouie");
            Students.Add(Student18);

            var Student19 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.White,
                AddressId = 32,
                UserName = "elowe@netscare.net",
                Email = "elowe@netscare.net",
                FirstName = "Ernest",
                LastName = "Lowe",
                GPA = 3.07m,
                DateOfBirth = new DateTime(2001, 12, 27),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student19.NormalizedUserName = Student19.UserName.ToUpper();
            Student19.NormalizedEmail = Student19.Email.ToUpper();
            Student19.PasswordHash = passwordHasher.HashPassword(Student19, "martin1234");
            Students.Add(Student19);

            var Student20 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.White,
                AddressId = 33,
                UserName = "cluce@gogle.com",
                Email = "cluce@gogle.com",
                FirstName = "Chuck",
                LastName = "Luce",
                GPA = 3.87m,
                DateOfBirth = new DateTime(2001, 12, 23),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student20.NormalizedUserName = Student20.UserName.ToUpper();
            Student20.NormalizedEmail = Student20.Email.ToUpper();
            Student20.PasswordHash = passwordHasher.HashPassword(Student20, "meganr34");
            Students.Add(Student20);

            var Student21 = new AppUser
            {
                Gender = Gender.Other,
                Ethnicity = Ethnicity.White,
                AddressId = 34,
                UserName = "mackcloud@george.com",
                Email = "mackcloud@george.com",
                FirstName = "Jennifer",
                LastName = "MacLeod",
                GPA = 4.00m,
                DateOfBirth = new DateTime(2000, 11, 12),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student21.NormalizedUserName = Student21.UserName.ToUpper();
            Student21.NormalizedEmail = Student21.Email.ToUpper();
            Student21.PasswordHash = passwordHasher.HashPassword(Student21, "meow88");
            Students.Add(Student21);

            var Student22 = new AppUser
            {
                Gender = Gender.Other,
                Ethnicity = Ethnicity.NativeHawaiianandOtherPacificIslander,
                AddressId = 35,
                UserName = "cmartin@beets.com",
                Email = "cmartin@beets.com",
                FirstName = "Elizabeth",
                LastName = "Markham",
                GPA = 3.53m,
                DateOfBirth = new DateTime(2000, 12, 21),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student22.NormalizedUserName = Student22.UserName.ToUpper();
            Student22.NormalizedEmail = Student22.Email.ToUpper();
            Student22.PasswordHash = passwordHasher.HashPassword(Student22, "mustangs");
            Students.Add(Student22);

            var Student23 = new AppUser
            {
                Gender = Gender.Other,
                Ethnicity = Ethnicity.White,
                AddressId = 36,
                UserName = "clarence@yoho.com",
                Email = "clarence@yoho.com",
                FirstName = "Clarence",
                LastName = "Martin",
                GPA = 3.11m,
                DateOfBirth = new DateTime(2002, 10, 27),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student23.NormalizedUserName = Student23.UserName.ToUpper();
            Student23.NormalizedEmail = Student23.Email.ToUpper();
            Student23.PasswordHash = passwordHasher.HashPassword(Student23, "mydogspot");
            Students.Add(Student23);

            var Student24 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.Hispanic,
                AddressId = 37,
                UserName = "gregmartinez@drdre.com",
                Email = "gregmartinez@drdre.com",
                FirstName = "Gregory",
                LastName = "Martinez",
                GPA = 3.43m,
                DateOfBirth = new DateTime(2003, 5, 11),
                GraduationDate = new DateTime(2025, 5, 6),
                PositionType = PositionType.I
            };
            Student24.NormalizedUserName = Student24.UserName.ToUpper();
            Student24.NormalizedEmail = Student24.Email.ToUpper();
            Student24.PasswordHash = passwordHasher.HashPassword(Student24, "nothinggood");
            Students.Add(Student24);

            var Student25 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.TwoOrMoreRaces,
                AddressId = 38,
                UserName = "cmiller@bob.com",
                Email = "cmiller@bob.com",
                FirstName = "Charles",
                LastName = "Miller",
                GPA = 3.14m,
                DateOfBirth = new DateTime(2001, 6, 16),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student25.NormalizedUserName = Student25.UserName.ToUpper();
            Student25.NormalizedEmail = Student25.Email.ToUpper();
            Student25.PasswordHash = passwordHasher.HashPassword(Student25, "onetime");
            Students.Add(Student25);

            var Student26 = new AppUser
            {
                Gender = Gender.F,
                Ethnicity = Ethnicity.NativeHawaiianandOtherPacificIslander,
                AddressId = 39,
                UserName = "knelson@aoll.com",
                Email = "knelson@aoll.com",
                FirstName = "Kelly",
                LastName = "Nelson",
                GPA = 3.03m,
                DateOfBirth = new DateTime(2003, 7, 23),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student26.NormalizedUserName = Student26.UserName.ToUpper();
            Student26.NormalizedEmail = Student26.Email.ToUpper();
            Student26.PasswordHash = passwordHasher.HashPassword(Student26, "painting");
            Students.Add(Student26);

            var Student27 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.Asian,
                AddressId = 40,
                UserName = "joewin@xfactor.com",
                Email = "joewin@xfactor.com",
                FirstName = "Joe",
                LastName = "Nguyen",
                GPA = 3.65m,
                DateOfBirth = new DateTime(2000, 12, 23),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student27.NormalizedUserName = Student27.UserName.ToUpper();
            Student27.NormalizedEmail = Student27.Email.ToUpper();
            Student27.PasswordHash = passwordHasher.HashPassword(Student27, "Password1");
            Students.Add(Student27);

            var Student28 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.White,
                AddressId = 41,
                UserName = "orielly@foxnews.cnn",
                Email = "orielly@foxnews.cnn",
                FirstName = "Bill",
                LastName = "O'Reilly",
                GPA = 3.46m,
                DateOfBirth = new DateTime(2001, 11, 24),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student28.NormalizedUserName = Student28.UserName.ToUpper();
            Student28.NormalizedEmail = Student28.Email.ToUpper();
            Student28.PasswordHash = passwordHasher.HashPassword(Student28, "penguin12");
            Students.Add(Student28);

            var Student29 = new AppUser
            {
                Gender = Gender.Other,
                Ethnicity = Ethnicity.White,
                AddressId = 42,
                UserName = "ankaisrad@gogle.com",
                Email = "ankaisrad@gogle.com",
                FirstName = "Anka",
                LastName = "Radkovich",
                GPA = 3.67m,
                DateOfBirth = new DateTime(2001, 8, 8),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student29.NormalizedUserName = Student29.UserName.ToUpper();
            Student29.NormalizedEmail = Student29.Email.ToUpper();
            Student29.PasswordHash = passwordHasher.HashPassword(Student29, "pepperoni");
            Students.Add(Student29);

            var Student30 = new AppUser
            {
                Gender = Gender.F,
                Ethnicity = Ethnicity.TwoOrMoreRaces,
                AddressId = 43,
                UserName = "megrhodes@freserve.co.uk",
                Email = "megrhodes@freserve.co.uk",
                FirstName = "Megan",
                LastName = "Rhodes",
                GPA = 3.14m,
                DateOfBirth = new DateTime(2001, 5, 20),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student30.NormalizedUserName = Student30.UserName.ToUpper();
            Student30.NormalizedEmail = Student30.Email.ToUpper();
            Student30.PasswordHash = passwordHasher.HashPassword(Student30, "potato");
            Students.Add(Student30);

            var Student31 = new AppUser
            {
                Gender = Gender.F,
                Ethnicity = Ethnicity.Asian,
                AddressId = 44,
                UserName = "erynrice@aoll.com",
                Email = "erynrice@aoll.com",
                FirstName = "Eryn",
                LastName = "Rice",
                GPA = 3.92m,
                DateOfBirth = new DateTime(2004, 4, 29),
                GraduationDate = new DateTime(2026, 5, 6),
                PositionType = PositionType.I
            };
            Student31.NormalizedUserName = Student31.UserName.ToUpper();
            Student31.NormalizedEmail = Student31.Email.ToUpper();
            Student31.PasswordHash = passwordHasher.HashPassword(Student31, "radgirl");
            Students.Add(Student31);

            var Student32 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.Hispanic,
                AddressId = 45,
                UserName = "jorge@noclue.com",
                Email = "jorge@noclue.com",
                FirstName = "Jorge",
                LastName = "Rodriguez",
                GPA = 3.64m,
                DateOfBirth = new DateTime(2002, 10, 3),
                GraduationDate = new DateTime(2025, 5, 6),
                PositionType = PositionType.I
            };
            Student32.NormalizedUserName = Student32.UserName.ToUpper();
            Student32.NormalizedEmail = Student32.Email.ToUpper();
            Student32.PasswordHash = passwordHasher.HashPassword(Student32, "raiders");
            Students.Add(Student32);

            var Student33 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.BlackOrAfricanAmerican,
                AddressId = 46,
                UserName = "mrrogers@lovelyday.com",
                Email = "mrrogers@lovelyday.com",
                FirstName = "Allen",
                LastName = "Rogers",
                GPA = 3.01m,
                DateOfBirth = new DateTime(2001, 2, 20),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student33.NormalizedUserName = Student33.UserName.ToUpper();
            Student33.NormalizedEmail = Student33.Email.ToUpper();
            Student33.PasswordHash = passwordHasher.HashPassword(Student33, "ricearoni");
            Students.Add(Student33);

            var Student34 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.White,
                AddressId = 47,
                UserName = "stjean@athome.com",
                Email = "stjean@athome.com",
                FirstName = "Olivier",
                LastName = "Saint-Jean",
                GPA = 3.24m,
                DateOfBirth = new DateTime(2002, 2, 26),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student34.NormalizedUserName = Student34.UserName.ToUpper();
            Student34.NormalizedEmail = Student34.Email.ToUpper();
            Student34.PasswordHash = passwordHasher.HashPassword(Student34, "rogerthat");
            Students.Add(Student34);

            var Student35 = new AppUser
            {
                Gender = Gender.F,
                Ethnicity = Ethnicity.White,
                AddressId = 48,
                UserName = "saunders@pen.com",
                Email = "saunders@pen.com",
                FirstName = "Sarah",
                LastName = "Saunders",
                GPA = 3.16m,
                DateOfBirth = new DateTime(2002, 2, 5),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student35.NormalizedUserName = Student35.UserName.ToUpper();
            Student35.NormalizedEmail = Student35.Email.ToUpper();
            Student35.PasswordHash = passwordHasher.HashPassword(Student35, "slowwind");
            Students.Add(Student35);

            var Student36 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.Hispanic,
                AddressId = 49,
                UserName = "willsheff@email.com",
                Email = "willsheff@email.com",
                FirstName = "William",
                LastName = "Sewell",
                GPA = 3.07m,
                DateOfBirth = new DateTime(2002, 10, 13),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student36.NormalizedUserName = Student36.UserName.ToUpper();
            Student36.NormalizedEmail = Student36.Email.ToUpper();
            Student36.PasswordHash = passwordHasher.HashPassword(Student36, "smitty444");
            Students.Add(Student36);

            var Student37 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.TwoOrMoreRaces,
                AddressId = 50,
                UserName = "sheffiled@gogle.com",
                Email = "sheffiled@gogle.com",
                FirstName = "Martin",
                LastName = "Sheffield",
                GPA = 3.36m,
                DateOfBirth = new DateTime(2002, 10, 11),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student37.NormalizedUserName = Student37.UserName.ToUpper();
            Student37.NormalizedEmail = Student37.Email.ToUpper();
            Student37.PasswordHash = passwordHasher.HashPassword(Student37, "snowsnow");
            Students.Add(Student37);

            var Student38 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.White,
                AddressId = 51,
                UserName = "johnsmith187@aoll.com",
                Email = "johnsmith187@aoll.com",
                FirstName = "John",
                LastName = "Smith",
                GPA = 3.57m,
                DateOfBirth = new DateTime(2001, 8, 19),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student38.NormalizedUserName = Student38.UserName.ToUpper();
            Student38.NormalizedEmail = Student38.Email.ToUpper();
            Student38.PasswordHash = passwordHasher.HashPassword(Student38, "something");
            Students.Add(Student38);

            var Student39 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.White,
                AddressId = 52,
                UserName = "dustroud@mail.com",
                Email = "dustroud@mail.com",
                FirstName = "Dustin",
                LastName = "Stroud",
                GPA = 3.49m,
                DateOfBirth = new DateTime(2002, 3, 5),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student39.NormalizedUserName = Student39.UserName.ToUpper();
            Student39.NormalizedEmail = Student39.Email.ToUpper();
            Student39.PasswordHash = passwordHasher.HashPassword(Student39, "spotmydog");
            Students.Add(Student39);

            var Student40 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.BlackOrAfricanAmerican,
                AddressId = 53,
                UserName = "estuart@anchor.net",
                Email = "estuart@anchor.net",
                FirstName = "Eric",
                LastName = "Stuart",
                GPA = 3.58m,
                DateOfBirth = new DateTime(2003, 4, 17),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student40.NormalizedUserName = Student40.UserName.ToUpper();
            Student40.NormalizedEmail = Student40.Email.ToUpper();
            Student40.PasswordHash = passwordHasher.HashPassword(Student40, "stewball");
            Students.Add(Student40);

            var Student41 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.NativeHawaiianandOtherPacificIslander,
                AddressId = 54,
                UserName = "peterstump@noclue.com",
                Email = "peterstump@noclue.com",
                FirstName = "Peter",
                LastName = "Stump",
                GPA = 2.55m,
                DateOfBirth = new DateTime(2002, 5, 9),
                GraduationDate = new DateTime(2025, 5, 6),
                PositionType = PositionType.I
            };
            Student41.NormalizedUserName = Student41.UserName.ToUpper();
            Student41.NormalizedEmail = Student41.Email.ToUpper();
            Student41.PasswordHash = passwordHasher.HashPassword(Student41, "tanner5454");
            Students.Add(Student41);

            var Student42 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.White,
                AddressId = 55,
                UserName = "jtanner@mustang.net",
                Email = "jtanner@mustang.net",
                FirstName = "Jeremy",
                LastName = "Tanner",
                GPA = 3.16m,
                DateOfBirth = new DateTime(2002, 12, 15),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student42.NormalizedUserName = Student42.UserName.ToUpper();
            Student42.NormalizedEmail = Student42.Email.ToUpper();
            Student42.PasswordHash = passwordHasher.HashPassword(Student42, "taylorbaylor");
            Students.Add(Student42);

            var Student43 = new AppUser
            {
                Gender = Gender.F,
                Ethnicity = Ethnicity.TwoOrMoreRaces,
                AddressId = 56,
                UserName = "taylordjay@aoll.com",
                Email = "taylordjay@aoll.com",
                FirstName = "Allison",
                LastName = "Taylor",
                GPA = 3.07m,
                DateOfBirth = new DateTime(2001, 7, 27),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student43.NormalizedUserName = Student43.UserName.ToUpper();
            Student43.NormalizedEmail = Student43.Email.ToUpper();
            Student43.PasswordHash = passwordHasher.HashPassword(Student43, "teeoff22");
            Students.Add(Student43);

            var Student44 = new AppUser
            {
                Gender = Gender.F,
                Ethnicity = Ethnicity.TwoOrMoreRaces,
                AddressId = 57,
                UserName = "rtaylor@gogle.com",
                Email = "rtaylor@gogle.com",
                FirstName = "Rachel",
                LastName = "Taylor",
                GPA = 2.88m,
                DateOfBirth = new DateTime(2003, 5, 16),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student44.NormalizedUserName = Student44.UserName.ToUpper();
            Student44.NormalizedEmail = Student44.Email.ToUpper();
            Student44.PasswordHash = passwordHasher.HashPassword(Student44, "texas1");
            Students.Add(Student44);

            var Student45 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.BlackOrAfricanAmerican,
                AddressId = 58,
                UserName = "teefrank@noclue.com",
                Email = "teefrank@noclue.com",
                FirstName = "Frank",
                LastName = "Tee",
                GPA = 3.50m,
                DateOfBirth = new DateTime(2003, 8, 22),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student45.NormalizedUserName = Student45.UserName.ToUpper();
            Student45.NormalizedEmail = Student45.Email.ToUpper();
            Student45.PasswordHash = passwordHasher.HashPassword(Student45, "toddy25");
            Students.Add(Student45);

            var Student46 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.Asian,
                AddressId = 59,
                UserName = "ctucker@alphabet.co.uk",
                Email = "ctucker@alphabet.co.uk",
                FirstName = "Clent",
                LastName = "Tucker",
                GPA = 3.04m,
                DateOfBirth = new DateTime(2001, 9, 28),
                GraduationDate = new DateTime(2024, 5, 6),
                PositionType = PositionType.I
            };
            Student46.NormalizedUserName = Student46.UserName.ToUpper();
            Student46.NormalizedEmail = Student46.Email.ToUpper();
            Student46.PasswordHash = passwordHasher.HashPassword(Student46, "tucksack1");
            Students.Add(Student46);

            var Student47 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.Hispanic,
                AddressId = 60,
                UserName = "avelasco@yoho.com",
                Email = "avelasco@yoho.com",
                FirstName = "Allen",
                LastName = "Velasco",
                GPA = 3.55m,
                DateOfBirth = new DateTime(2003, 6, 27),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student47.NormalizedUserName = Student47.UserName.ToUpper();
            Student47.NormalizedEmail = Student47.Email.ToUpper();
            Student47.PasswordHash = passwordHasher.HashPassword(Student47, "vinovino");
            Students.Add(Student47);

            var Student48 = new AppUser
            {
                Gender = Gender.F,
                Ethnicity = Ethnicity.Hispanic,
                AddressId = 61,
                UserName = "vinovino@grapes.com",
                Email = "vinovino@grapes.com",
                FirstName = "Janet",
                LastName = "Vino",
                GPA = 3.28m,
                DateOfBirth = new DateTime(1997, 12, 17),
                GraduationDate = new DateTime(2025, 5, 6),
                PositionType = PositionType.I
            };
            Student48.NormalizedUserName = Student48.UserName.ToUpper();
            Student48.NormalizedEmail = Student48.Email.ToUpper();
            Student48.PasswordHash = passwordHasher.HashPassword(Student48, "whatever");
            Students.Add(Student48);

            var Student49 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.NativeHawaiianandOtherPacificIslander,
                AddressId = 62,
                UserName = "westj@pioneer.net",
                Email = "westj@pioneer.net",
                FirstName = "Jake",
                LastName = "West",
                GPA = 3.66m,
                DateOfBirth = new DateTime(2002, 11, 16),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student49.NormalizedUserName = Student49.UserName.ToUpper();
            Student49.NormalizedEmail = Student49.Email.ToUpper();
            Student49.PasswordHash = passwordHasher.HashPassword(Student49, "whocares");
            Students.Add(Student49);

            var Student50 = new AppUser
            {
                Gender = Gender.M,
                Ethnicity = Ethnicity.TwoOrMoreRaces,
                AddressId = 63,
                UserName = "winner@hootmail.com",
                Email = "winner@hootmail.com",
                FirstName = "Louis",
                LastName = "Winthorpe",
                GPA = 2.57m,
                DateOfBirth = new DateTime(2001, 1, 20),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student50.NormalizedUserName = Student50.UserName.ToUpper();
            Student50.NormalizedEmail = Student50.Email.ToUpper();
            Student50.PasswordHash = passwordHasher.HashPassword(Student50, "woodyman1");
            Students.Add(Student50);

            var Student51 = new AppUser
            {
                Gender = Gender.F,
                Ethnicity = Ethnicity.White,
                AddressId = 64,
                UserName = "rwood@voyager.net",
                Email = "rwood@voyager.net",
                FirstName = "Reagan",
                LastName = "Wood",
                GPA = 3.78m,
                DateOfBirth = new DateTime(2001, 12, 25),
                GraduationDate = new DateTime(2023, 5, 6),
                PositionType = PositionType.FT
            };
            Student51.NormalizedUserName = Student51.UserName.ToUpper();
            Student51.NormalizedEmail = Student51.Email.ToUpper();
            Student51.PasswordHash = passwordHasher.HashPassword(Student51, "xcellent");
            Students.Add(Student51);

            builder.Entity<AppUser>().HasData(Students);


            // Seed Student Roles

            List<IdentityUserRole<string>> StudentRoles = new List<IdentityUserRole<string>>();

            var StudentRoleId = Roles.First(q => q.Name == "Student").Id;

            foreach (var Student in Students)
            {
                StudentRoles.Add(new IdentityUserRole<string>
                {
                    UserId = Student.Id,
                    RoleId = StudentRoleId
                });
            }

            builder.Entity<IdentityUserRole<string>>().HasData(StudentRoles);

            // Seed Student Majors
            List<AppUserMajor> AppUserMajors = new List<AppUserMajor>();


            var AppUserMajor1 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "cbaker@example.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            AppUserMajors.Add(AppUserMajor1);

            var AppUserMajor2 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "banker@longhorn.net").Id,
                MajorId = Majors.First(m => m.MajorName == "International Business").MajorId
            };
            AppUserMajors.Add(AppUserMajor2);

            var AppUserMajor3 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "franco@example.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            AppUserMajors.Add(AppUserMajor3);

            var AppUserMajor4 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "wchang@example.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            AppUserMajors.Add(AppUserMajor4);

            var AppUserMajor5 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "limchou@gogle.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            AppUserMajors.Add(AppUserMajor5);

            var AppUserMajor6 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "shdixon@aoll.com").Id,
                MajorId = Majors.First(m => m.MajorName == "International Business").MajorId
            };
            AppUserMajors.Add(AppUserMajor6);

            var AppUserMajor7 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "j.b.evans@aheca.org").Id,
                MajorId = Majors.First(m => m.MajorName == "Accounting").MajorId
            };
            AppUserMajors.Add(AppUserMajor7);

            var AppUserMajor8 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "feeley@penguin.org").Id,
                MajorId = Majors.First(m => m.MajorName == "Marketing").MajorId
            };
            AppUserMajors.Add(AppUserMajor8);

            var AppUserMajor9 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "tfreeley@minnetonka.ci.us").Id,
                MajorId = Majors.First(m => m.MajorName == "Accounting").MajorId
            };
            AppUserMajors.Add(AppUserMajor9);

            var AppUserMajor10 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "mgarcia@gogle.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            AppUserMajors.Add(AppUserMajor10);

            var AppUserMajor11 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "chaley@thug.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            AppUserMajors.Add(AppUserMajor11);

            var AppUserMajor12 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "jeffh@sonic.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Science and Technology Management").MajorId
            };
            AppUserMajors.Add(AppUserMajor12);

            var AppUserMajor13 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "wjhearniii@umich.org").Id,
                MajorId = Majors.First(m => m.MajorName == "Canfield Business Honors Program").MajorId
            };
            AppUserMajors.Add(AppUserMajor13);

            var AppUserMajor14 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "ahick@yaho.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Supply Chain Management").MajorId
            };
            AppUserMajors.Add(AppUserMajor14);

            var AppUserMajor15 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "ingram@jack.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Supply Chain Management").MajorId
            };
            AppUserMajors.Add(AppUserMajor15);

            var AppUserMajor16 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "toddj@yourmom.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            AppUserMajors.Add(AppUserMajor16);

            var AppUserMajor17 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "thequeen@aska.net").Id,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            AppUserMajors.Add(AppUserMajor17);

            var AppUserMajor18 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "linebacker@gogle.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Accounting").MajorId
            };
            AppUserMajors.Add(AppUserMajor18);

            var AppUserMajor19 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "elowe@netscare.net").Id,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            AppUserMajors.Add(AppUserMajor19);

            var AppUserMajor20 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "cluce@gogle.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Accounting").MajorId
            };
            AppUserMajors.Add(AppUserMajor20);

            var AppUserMajor21 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "mackcloud@george.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            AppUserMajors.Add(AppUserMajor21);

            var AppUserMajor22 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "cmartin@beets.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Canfield Business Honors Program").MajorId
            };
            AppUserMajors.Add(AppUserMajor22);

            var AppUserMajor23 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "clarence@yoho.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Supply Chain Management").MajorId
            };
            AppUserMajors.Add(AppUserMajor23);

            var AppUserMajor24 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "gregmartinez@drdre.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Canfield Business Honors Program").MajorId
            };
            AppUserMajors.Add(AppUserMajor24);

            var AppUserMajor25 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "cmiller@bob.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Management").MajorId
            };
            AppUserMajors.Add(AppUserMajor25);

            var AppUserMajor26 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "knelson@aoll.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            AppUserMajors.Add(AppUserMajor26);

            var AppUserMajor27 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "joewin@xfactor.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Management").MajorId
            };
            AppUserMajors.Add(AppUserMajor27);

            var AppUserMajor28 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "orielly@foxnews.cnn").Id,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            AppUserMajors.Add(AppUserMajor28);

            var AppUserMajor29 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "ankaisrad@gogle.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Canfield Business Honors Program").MajorId
            };
            AppUserMajors.Add(AppUserMajor29);

            var AppUserMajor30 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "megrhodes@freserve.co.uk").Id,
                MajorId = Majors.First(m => m.MajorName == "Management").MajorId
            };
            AppUserMajors.Add(AppUserMajor30);

            var AppUserMajor31 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "erynrice@aoll.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Marketing").MajorId
            };
            AppUserMajors.Add(AppUserMajor31);

            var AppUserMajor32 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "jorge@noclue.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            AppUserMajors.Add(AppUserMajor32);

            var AppUserMajor33 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "mrrogers@lovelyday.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Marketing").MajorId
            };
            AppUserMajors.Add(AppUserMajor33);

            var AppUserMajor34 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "stjean@athome.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Science and Technology Management").MajorId
            };
            AppUserMajors.Add(AppUserMajor34);

            var AppUserMajor35 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "saunders@pen.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Supply Chain Management").MajorId
            };
            AppUserMajors.Add(AppUserMajor35);

            var AppUserMajor36 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "willsheff@email.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            AppUserMajors.Add(AppUserMajor36);

            var AppUserMajor37 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "sheffiled@gogle.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            AppUserMajors.Add(AppUserMajor37);

            var AppUserMajor38 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "johnsmith187@aoll.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            AppUserMajors.Add(AppUserMajor38);

            var AppUserMajor39 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "dustroud@mail.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Marketing").MajorId
            };
            AppUserMajors.Add(AppUserMajor39);

            var AppUserMajor40 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "estuart@anchor.net").Id,
                MajorId = Majors.First(m => m.MajorName == "Canfield Business Honors Program").MajorId
            };
            AppUserMajors.Add(AppUserMajor40);

            var AppUserMajor41 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "peterstump@noclue.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Supply Chain Management").MajorId
            };
            AppUserMajors.Add(AppUserMajor41);

            var AppUserMajor42 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "jtanner@mustang.net").Id,
                MajorId = Majors.First(m => m.MajorName == "Management").MajorId
            };
            AppUserMajors.Add(AppUserMajor42);

            var AppUserMajor43 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "taylordjay@aoll.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Marketing").MajorId
            };
            AppUserMajors.Add(AppUserMajor43);

            var AppUserMajor44 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "rtaylor@gogle.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            AppUserMajors.Add(AppUserMajor44);

            var AppUserMajor45 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "teefrank@noclue.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            AppUserMajors.Add(AppUserMajor45);

            var AppUserMajor46 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "ctucker@alphabet.co.uk").Id,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            AppUserMajors.Add(AppUserMajor46);

            var AppUserMajor47 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "avelasco@yoho.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            AppUserMajors.Add(AppUserMajor47);

            var AppUserMajor48 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "vinovino@grapes.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Canfield Business Honors Program").MajorId
            };
            AppUserMajors.Add(AppUserMajor48);

            var AppUserMajor49 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "westj@pioneer.net").Id,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            AppUserMajors.Add(AppUserMajor49);

            var AppUserMajor50 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "winner@hootmail.com").Id,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            AppUserMajors.Add(AppUserMajor50);

            var AppUserMajor51 = new AppUserMajor
            {
                AppUserId = Students.First(s => s.UserName == "rwood@voyager.net").Id,
                MajorId = Majors.First(m => m.MajorName == "Accounting").MajorId
            };
            AppUserMajors.Add(AppUserMajor51);

            builder.Entity<AppUserMajor>().HasData(AppUserMajors);

            // Seed Positions
            List<Position> Positions = new List<Position>();


            var Position1 = new Position
            {
                PositionId = 1,
                PositionName = "Financial Planning Intern",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "32801" && a.Street == "400 South Orange Avenue").AddressId,
                Deadline = new DateTime(2023, 6, 1),
                PositionType = PositionType.I,
                CompanyId = Companies.First(c => c.CompanyName == "Academy Sports & Outdoors").CompanyId,
            };
            Positions.Add(Position1);

            var Position2 = new Position
            {
                PositionId = 2,
                PositionName = "Digital Product Manager",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "77002" && a.Street == "901 Bagby Sreet").AddressId,
                Deadline = new DateTime(2023, 6, 1),
                PositionType = PositionType.FT,
                CompanyId = Companies.First(c => c.CompanyName == "Academy Sports & Outdoors").CompanyId,
            };
            Positions.Add(Position2);

            var Position3 = new Position
            {
                PositionId = 3,
                PositionName = "Consultant ",
                PositionDescription = "Full-time consultant position",
                AddressId = Addresses.First(a => a.PostalCode == "77002" && a.Street == "1301 Fannin Street").AddressId,
                Deadline = new DateTime(2023, 4, 15),
                PositionType = PositionType.FT,
                CompanyId = Companies.First(c => c.CompanyName == "Accenture").CompanyId,
            };
            Positions.Add(Position3);

            var Position4 = new Position
            {
                PositionId = 4,
                PositionName = "Digital Intern",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "75039" && a.Street == "5205 North O'Connor Boulevard").AddressId,
                Deadline = new DateTime(2023, 5, 20),
                PositionType = PositionType.I,
                CompanyId = Companies.First(c => c.CompanyName == "Accenture").CompanyId,
            };
            Positions.Add(Position4);

            var Position5 = new Position
            {
                PositionId = 5,
                PositionName = "Marketing Intern",
                PositionDescription = "Help our marketing team develop new advertising strategies for local Austin businesses",
                AddressId = Addresses.First(a => a.PostalCode == "78758" && a.Street == "10414 McKalla Place").AddressId,
                Deadline = new DateTime(2023, 4, 30),
                PositionType = PositionType.I,
                CompanyId = Companies.First(c => c.CompanyName == "Adlucent").CompanyId,
            };
            Positions.Add(Position5);

            var Position6 = new Position
            {
                PositionId = 6,
                PositionName = "Sales Associate",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "90015" && a.Street == "1111 South Figueroa Street").AddressId,
                Deadline = new DateTime(2023, 4, 1),
                PositionType = PositionType.FT,
                CompanyId = Companies.First(c => c.CompanyName == "Aon").CompanyId,
            };
            Positions.Add(Position6);

            var Position7 = new Position
            {
                PositionId = 7,
                PositionName = "Project Manager",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "60612" && a.Street == "1901 West Madison Street").AddressId,
                Deadline = new DateTime(2023, 6, 1),
                PositionType = PositionType.FT,
                CompanyId = Companies.First(c => c.CompanyName == "Aon").CompanyId,
            };
            Positions.Add(Position7);

            var Position8 = new Position
            {
                PositionId = 8,
                PositionName = "Web Development",
                PositionDescription = "Developing a great new website for customer portfolio management",
                AddressId = Addresses.First(a => a.PostalCode == "23173" && a.Street == "410 Westhampton Way").AddressId,
                Deadline = new DateTime(2023, 3, 14),
                PositionType = PositionType.FT,
                CompanyId = Companies.First(c => c.CompanyName == "Capital One").CompanyId,
            };
            Positions.Add(Position8);

            var Position9 = new Position
            {
                PositionId = 9,
                PositionName = "Financial Analyst",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "23173" && a.Street == "410 Westhampton Way").AddressId,
                Deadline = new DateTime(2023, 4, 15),
                PositionType = PositionType.FT,
                CompanyId = Companies.First(c => c.CompanyName == "Capital One").CompanyId,
            };
            Positions.Add(Position9);

            var Position10 = new Position
            {
                PositionId = 10,
                PositionName = "Analyst Development Program",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "75075" && a.Street == "2200 Independence Parkway").AddressId,
                Deadline = new DateTime(2023, 5, 20),
                PositionType = PositionType.I,
                CompanyId = Companies.First(c => c.CompanyName == "Capital One").CompanyId,
            };
            Positions.Add(Position10);

            var Position11 = new Position
            {
                PositionId = 11,
                PositionName = "Accounting Intern",
                PositionDescription = "Work in our audit group",
                AddressId = Addresses.First(a => a.PostalCode == "78701" && a.Street == "500 West 2nd Street Suite 1600").AddressId,
                Deadline = new DateTime(2023, 5, 1),
                PositionType = PositionType.I,
                CompanyId = Companies.First(c => c.CompanyName == "Deloitte").CompanyId,
            };
            Positions.Add(Position11);

            var Position12 = new Position
            {
                PositionId = 12,
                PositionName = "Account Manager",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "75201" && a.Street == "2200 Ross Avenue").AddressId,
                Deadline = new DateTime(2023, 2, 25),
                PositionType = PositionType.FT,
                CompanyId = Companies.First(c => c.CompanyName == "Deloitte").CompanyId,
            };
            Positions.Add(Position12);

            var Position13 = new Position
            {
                PositionId = 13,
                PositionName = "Amenities Analytics Intern",
                PositionDescription = "Help analyze our amenities and customer rewards programs",
                AddressId = Addresses.First(a => a.PostalCode == "10019" && a.Street == "1335 6th Avenue").AddressId,
                Deadline = new DateTime(2023, 3, 30),
                PositionType = PositionType.I,
                CompanyId = Companies.First(c => c.CompanyName == "Hilton Worldwide").CompanyId,
            };
            Positions.Add(Position13);

            var Position14 = new Position
            {
                PositionId = 14,
                PositionName = "Junior Programmer",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "98052" && a.Street == "1 Microsoft Way").AddressId,
                Deadline = new DateTime(2023, 4, 3),
                PositionType = PositionType.I,
                CompanyId = Companies.First(c => c.CompanyName == "Microsoft").CompanyId,
            };
            Positions.Add(Position14);

            var Position15 = new Position
            {
                PositionId = 15,
                PositionName = "Corporate Recruiting Intern",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "98052" && a.Street == "1 Microsoft Way").AddressId,
                Deadline = new DateTime(2023, 4, 30),
                PositionType = PositionType.I,
                CompanyId = Companies.First(c => c.CompanyName == "Microsoft").CompanyId,
            };
            Positions.Add(Position15);

            var Position16 = new Position
            {
                PositionId = 16,
                PositionName = "Business Analyst",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "78712" && a.Street == "2001 Robert Dedman Drive").AddressId,
                Deadline = new DateTime(2023, 5, 31),
                PositionType = PositionType.FT,
                CompanyId = Companies.First(c => c.CompanyName == "Microsoft").CompanyId,
            };
            Positions.Add(Position16);

            var Position17 = new Position
            {
                PositionId = 17,
                PositionName = "Product Marketing Intern",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "98052" && a.Street == "1 Microsoft Way").AddressId,
                Deadline = new DateTime(2023, 6, 1),
                PositionType = PositionType.I,
                CompanyId = Companies.First(c => c.CompanyName == "Microsoft").CompanyId,
            };
            Positions.Add(Position17);

            var Position18 = new Position
            {
                PositionId = 18,
                PositionName = "Program Manager",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "98052" && a.Street == "1 Microsoft Way").AddressId,
                Deadline = new DateTime(2023, 6, 1),
                PositionType = PositionType.FT,
                CompanyId = Companies.First(c => c.CompanyName == "Microsoft").CompanyId,
            };
            Positions.Add(Position18);

            var Position19 = new Position
            {
                PositionId = 19,
                PositionName = "Security Analyst",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "98052" && a.Street == "1 Microsoft Way").AddressId,
                Deadline = new DateTime(2023, 6, 1),
                PositionType = PositionType.FT,
                CompanyId = Companies.First(c => c.CompanyName == "Microsoft").CompanyId,
            };
            Positions.Add(Position19);

            var Position20 = new Position
            {
                PositionId = 20,
                PositionName = "Supply Chain Internship",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "77036" && a.Street == "8900 Bellaire Boulevard").AddressId,
                Deadline = new DateTime(2023, 5, 5),
                PositionType = PositionType.I,
                CompanyId = Companies.First(c => c.CompanyName == "Shell").CompanyId,
            };
            Positions.Add(Position20);

            var Position21 = new Position
            {
                PositionId = 21,
                PositionName = "Procurements Associate",
                PositionDescription = "Handle procurement and vendor accounts",
                AddressId = Addresses.First(a => a.PostalCode == "77036" && a.Street == "8900 Bellaire Boulevard").AddressId,
                Deadline = new DateTime(2023, 5, 30),
                PositionType = PositionType.FT,
                CompanyId = Companies.First(c => c.CompanyName == "Shell").CompanyId,
            };
            Positions.Add(Position21);

            var Position22 = new Position
            {
                PositionId = 22,
                PositionName = "Programmer Analyst",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "55403" && a.Street == "1000 Nicollet Mall").AddressId,
                Deadline = new DateTime(2023, 5, 15),
                PositionType = PositionType.FT,
                CompanyId = Companies.First(c => c.CompanyName == "Target").CompanyId,
            };
            Positions.Add(Position22);

            var Position23 = new Position
            {
                PositionId = 23,
                PositionName = "Intern",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "55403" && a.Street == "1000 Nicollet Mall").AddressId,
                Deadline = new DateTime(2023, 5, 15),
                PositionType = PositionType.I,
                CompanyId = Companies.First(c => c.CompanyName == "Target").CompanyId,
            };
            Positions.Add(Position23);

            var Position24 = new Position
            {
                PositionId = 24,
                PositionName = "IT Rotational Program",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "75202" && a.Street == "1717 McKinney Avenue").AddressId,
                Deadline = new DateTime(2023, 5, 30),
                PositionType = PositionType.FT,
                CompanyId = Companies.First(c => c.CompanyName == "Texas Instruments").CompanyId,
            };
            Positions.Add(Position24);

            var Position25 = new Position
            {
                PositionId = 25,
                PositionName = "Sales Rotational Program",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "75202" && a.Street == "1717 McKinney Avenue").AddressId,
                Deadline = new DateTime(2023, 5, 30),
                PositionType = PositionType.FT,
                CompanyId = Companies.First(c => c.CompanyName == "Texas Instruments").CompanyId,
            };
            Positions.Add(Position25);

            var Position26 = new Position
            {
                PositionId = 26,
                PositionName = "Accounting Rotational Program",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "78731" && a.Street == "2825 Hancock Drive").AddressId,
                Deadline = new DateTime(2023, 5, 30),
                PositionType = PositionType.FT,
                CompanyId = Companies.First(c => c.CompanyName == "Texas Instruments").CompanyId,
            };
            Positions.Add(Position26);

            var Position27 = new Position
            {
                PositionId = 27,
                PositionName = "Pilot",
                PositionDescription = "",
                AddressId = Addresses.First(a => a.PostalCode == "76107" && a.Street == "1911 Montgomery Street").AddressId,
                Deadline = new DateTime(2023, 10, 8),
                PositionType = PositionType.FT,
                CompanyId = Companies.First(c => c.CompanyName == "United Airlines").CompanyId,
            };
            Positions.Add(Position27);

            builder.Entity<Position>().HasData(Positions);


            // Seed Position Majors
            List<PositionMajor> PositionMajors = new List<PositionMajor>();


            var PositionMajor1 = new PositionMajor
            {
                PositionId = 1,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            PositionMajors.Add(PositionMajor1);

            var PositionMajor2 = new PositionMajor
            {
                PositionId = 1,
                MajorId = Majors.First(m => m.MajorName == "Accounting").MajorId
            };
            PositionMajors.Add(PositionMajor2);

            var PositionMajor3 = new PositionMajor
            {
                PositionId = 1,
                MajorId = Majors.First(m => m.MajorName == "Canfield Business Honors Program").MajorId
            };
            PositionMajors.Add(PositionMajor3);

            var PositionMajor4 = new PositionMajor
            {
                PositionId = 2,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            PositionMajors.Add(PositionMajor4);

            var PositionMajor5 = new PositionMajor
            {
                PositionId = 2,
                MajorId = Majors.First(m => m.MajorName == "Marketing").MajorId
            };
            PositionMajors.Add(PositionMajor5);

            var PositionMajor6 = new PositionMajor
            {
                PositionId = 2,
                MajorId = Majors.First(m => m.MajorName == "Canfield Business Honors Program").MajorId
            };
            PositionMajors.Add(PositionMajor6);

            var PositionMajor7 = new PositionMajor
            {
                PositionId = 2,
                MajorId = Majors.First(m => m.MajorName == "Management").MajorId
            };
            PositionMajors.Add(PositionMajor7);

            var PositionMajor8 = new PositionMajor
            {
                PositionId = 3,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            PositionMajors.Add(PositionMajor8);

            var PositionMajor9 = new PositionMajor
            {
                PositionId = 3,
                MajorId = Majors.First(m => m.MajorName == "Accounting").MajorId
            };
            PositionMajors.Add(PositionMajor9);

            var PositionMajor10 = new PositionMajor
            {
                PositionId = 3,
                MajorId = Majors.First(m => m.MajorName == "Canfield Business Honors Program").MajorId
            };
            PositionMajors.Add(PositionMajor10);

            var PositionMajor11 = new PositionMajor
            {
                PositionId = 4,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            PositionMajors.Add(PositionMajor11);

            var PositionMajor12 = new PositionMajor
            {
                PositionId = 4,
                MajorId = Majors.First(m => m.MajorName == "Marketing").MajorId
            };
            PositionMajors.Add(PositionMajor12);

            var PositionMajor13 = new PositionMajor
            {
                PositionId = 5,
                MajorId = Majors.First(m => m.MajorName == "Marketing").MajorId
            };
            PositionMajors.Add(PositionMajor13);

            var PositionMajor14 = new PositionMajor
            {
                PositionId = 6,
                MajorId = Majors.First(m => m.MajorName == "Accounting").MajorId
            };
            PositionMajors.Add(PositionMajor14);

            var PositionMajor15 = new PositionMajor
            {
                PositionId = 6,
                MajorId = Majors.First(m => m.MajorName == "Marketing").MajorId
            };
            PositionMajors.Add(PositionMajor15);

            var PositionMajor16 = new PositionMajor
            {
                PositionId = 6,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            PositionMajors.Add(PositionMajor16);

            var PositionMajor17 = new PositionMajor
            {
                PositionId = 7,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            PositionMajors.Add(PositionMajor17);

            var PositionMajor18 = new PositionMajor
            {
                PositionId = 7,
                MajorId = Majors.First(m => m.MajorName == "Supply Chain Management").MajorId
            };
            PositionMajors.Add(PositionMajor18);

            var PositionMajor19 = new PositionMajor
            {
                PositionId = 7,
                MajorId = Majors.First(m => m.MajorName == "Accounting").MajorId
            };
            PositionMajors.Add(PositionMajor19);

            var PositionMajor20 = new PositionMajor
            {
                PositionId = 7,
                MajorId = Majors.First(m => m.MajorName == "Marketing").MajorId
            };
            PositionMajors.Add(PositionMajor20);

            var PositionMajor21 = new PositionMajor
            {
                PositionId = 7,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            PositionMajors.Add(PositionMajor21);

            var PositionMajor22 = new PositionMajor
            {
                PositionId = 7,
                MajorId = Majors.First(m => m.MajorName == "International Business").MajorId
            };
            PositionMajors.Add(PositionMajor22);

            var PositionMajor23 = new PositionMajor
            {
                PositionId = 7,
                MajorId = Majors.First(m => m.MajorName == "Canfield Business Honors Program").MajorId
            };
            PositionMajors.Add(PositionMajor23);

            var PositionMajor24 = new PositionMajor
            {
                PositionId = 8,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            PositionMajors.Add(PositionMajor24);

            var PositionMajor25 = new PositionMajor
            {
                PositionId = 9,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            PositionMajors.Add(PositionMajor25);

            var PositionMajor26 = new PositionMajor
            {
                PositionId = 10,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            PositionMajors.Add(PositionMajor26);

            var PositionMajor27 = new PositionMajor
            {
                PositionId = 10,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            PositionMajors.Add(PositionMajor27);

            var PositionMajor28 = new PositionMajor
            {
                PositionId = 10,
                MajorId = Majors.First(m => m.MajorName == "Canfield Business Honors Program").MajorId
            };
            PositionMajors.Add(PositionMajor28);

            var PositionMajor29 = new PositionMajor
            {
                PositionId = 11,
                MajorId = Majors.First(m => m.MajorName == "Accounting").MajorId
            };
            PositionMajors.Add(PositionMajor29);

            var PositionMajor30 = new PositionMajor
            {
                PositionId = 12,
                MajorId = Majors.First(m => m.MajorName == "Accounting").MajorId
            };
            PositionMajors.Add(PositionMajor30);

            var PositionMajor31 = new PositionMajor
            {
                PositionId = 12,
                MajorId = Majors.First(m => m.MajorName == "Canfield Business Honors Program").MajorId
            };
            PositionMajors.Add(PositionMajor31);

            var PositionMajor32 = new PositionMajor
            {
                PositionId = 13,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            PositionMajors.Add(PositionMajor32);

            var PositionMajor33 = new PositionMajor
            {
                PositionId = 13,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            PositionMajors.Add(PositionMajor33);

            var PositionMajor34 = new PositionMajor
            {
                PositionId = 13,
                MajorId = Majors.First(m => m.MajorName == "Marketing").MajorId
            };
            PositionMajors.Add(PositionMajor34);

            var PositionMajor35 = new PositionMajor
            {
                PositionId = 13,
                MajorId = Majors.First(m => m.MajorName == "Canfield Business Honors Program").MajorId
            };
            PositionMajors.Add(PositionMajor35);

            var PositionMajor36 = new PositionMajor
            {
                PositionId = 14,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            PositionMajors.Add(PositionMajor36);

            var PositionMajor37 = new PositionMajor
            {
                PositionId = 15,
                MajorId = Majors.First(m => m.MajorName == "Management").MajorId
            };
            PositionMajors.Add(PositionMajor37);

            var PositionMajor38 = new PositionMajor
            {
                PositionId = 16,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            PositionMajors.Add(PositionMajor38);

            var PositionMajor39 = new PositionMajor
            {
                PositionId = 17,
                MajorId = Majors.First(m => m.MajorName == "Marketing").MajorId
            };
            PositionMajors.Add(PositionMajor39);

            var PositionMajor40 = new PositionMajor
            {
                PositionId = 17,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            PositionMajors.Add(PositionMajor40);

            var PositionMajor41 = new PositionMajor
            {
                PositionId = 18,
                MajorId = Majors.First(m => m.MajorName == "Marketing").MajorId
            };
            PositionMajors.Add(PositionMajor41);

            var PositionMajor42 = new PositionMajor
            {
                PositionId = 18,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            PositionMajors.Add(PositionMajor42);

            var PositionMajor43 = new PositionMajor
            {
                PositionId = 19,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            PositionMajors.Add(PositionMajor43);

            var PositionMajor44 = new PositionMajor
            {
                PositionId = 20,
                MajorId = Majors.First(m => m.MajorName == "Supply Chain Management").MajorId
            };
            PositionMajors.Add(PositionMajor44);

            var PositionMajor45 = new PositionMajor
            {
                PositionId = 21,
                MajorId = Majors.First(m => m.MajorName == "Supply Chain Management").MajorId
            };
            PositionMajors.Add(PositionMajor45);

            var PositionMajor46 = new PositionMajor
            {
                PositionId = 22,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            PositionMajors.Add(PositionMajor46);

            var PositionMajor47 = new PositionMajor
            {
                PositionId = 23,
                MajorId = Majors.First(m => m.MajorName == "Accounting").MajorId
            };
            PositionMajors.Add(PositionMajor47);

            var PositionMajor48 = new PositionMajor
            {
                PositionId = 23,
                MajorId = Majors.First(m => m.MajorName == "Canfield Business Honors Program").MajorId
            };
            PositionMajors.Add(PositionMajor48);

            var PositionMajor49 = new PositionMajor
            {
                PositionId = 23,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            PositionMajors.Add(PositionMajor49);

            var PositionMajor51 = new PositionMajor
            {
                PositionId = 23,
                MajorId = Majors.First(m => m.MajorName == "International Business").MajorId
            };
            PositionMajors.Add(PositionMajor51);

            var PositionMajor52 = new PositionMajor
            {
                PositionId = 23,
                MajorId = Majors.First(m => m.MajorName == "Management").MajorId
            };
            PositionMajors.Add(PositionMajor52);

            var PositionMajor53 = new PositionMajor
            {
                PositionId = 23,
                MajorId = Majors.First(m => m.MajorName == "Marketing").MajorId
            };
            PositionMajors.Add(PositionMajor53);

            var PositionMajor55 = new PositionMajor
            {
                PositionId = 23,
                MajorId = Majors.First(m => m.MajorName == "Supply Chain Management").MajorId
            };
            PositionMajors.Add(PositionMajor55);

            var PositionMajor56 = new PositionMajor
            {
                PositionId = 23,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            PositionMajors.Add(PositionMajor56);

            var PositionMajor57 = new PositionMajor
            {
                PositionId = 23,
                MajorId = Majors.First(m => m.MajorName == "Science and Technology Management").MajorId
            };
            PositionMajors.Add(PositionMajor57);

            var PositionMajor58 = new PositionMajor
            {
                PositionId = 24,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            PositionMajors.Add(PositionMajor58);

            var PositionMajor59 = new PositionMajor
            {
                PositionId = 25,
                MajorId = Majors.First(m => m.MajorName == "Marketing").MajorId
            };
            PositionMajors.Add(PositionMajor59);

            var PositionMajor60 = new PositionMajor
            {
                PositionId = 25,
                MajorId = Majors.First(m => m.MajorName == "Management").MajorId
            };
            PositionMajors.Add(PositionMajor60);

            var PositionMajor61 = new PositionMajor
            {
                PositionId = 25,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            PositionMajors.Add(PositionMajor61);

            var PositionMajor62 = new PositionMajor
            {
                PositionId = 25,
                MajorId = Majors.First(m => m.MajorName == "Accounting").MajorId
            };
            PositionMajors.Add(PositionMajor62);

            var PositionMajor63 = new PositionMajor
            {
                PositionId = 26,
                MajorId = Majors.First(m => m.MajorName == "Accounting").MajorId
            };
            PositionMajors.Add(PositionMajor63);

            var PositionMajor64 = new PositionMajor
            {
                PositionId = 27,
                MajorId = Majors.First(m => m.MajorName == "Management Information Systems").MajorId
            };
            PositionMajors.Add(PositionMajor64);

            var PositionMajor65 = new PositionMajor
            {
                PositionId = 27,
                MajorId = Majors.First(m => m.MajorName == "Supply Chain Management").MajorId
            };
            PositionMajors.Add(PositionMajor65);

            var PositionMajor66 = new PositionMajor
            {
                PositionId = 27,
                MajorId = Majors.First(m => m.MajorName == "Accounting").MajorId
            };
            PositionMajors.Add(PositionMajor66);

            var PositionMajor67 = new PositionMajor
            {
                PositionId = 27,
                MajorId = Majors.First(m => m.MajorName == "Marketing").MajorId
            };
            PositionMajors.Add(PositionMajor67);

            var PositionMajor68 = new PositionMajor
            {
                PositionId = 27,
                MajorId = Majors.First(m => m.MajorName == "Finance").MajorId
            };
            PositionMajors.Add(PositionMajor68);

            var PositionMajor69 = new PositionMajor
            {
                PositionId = 27,
                MajorId = Majors.First(m => m.MajorName == "International Business").MajorId
            };
            PositionMajors.Add(PositionMajor69);

            var PositionMajor70 = new PositionMajor
            {
                PositionId = 27,
                MajorId = Majors.First(m => m.MajorName == "Canfield Business Honors Program").MajorId
            };
            PositionMajors.Add(PositionMajor70);

            builder.Entity<PositionMajor>().HasData(PositionMajors);

            // Seed Applications
            List<AppUserPosition> StudentPositions = new List<AppUserPosition>();

            Int32 Company1Id = Companies.First(c => c.CompanyName == "Adlucent").CompanyId;
            var StudentPosition1 = new AppUserPosition
            {
                AppUserPositionId = 1,
                PositionId = Positions.First(p => p.CompanyId == Company1Id && p.PositionName == "Marketing Intern").PositionId,
                StudentId = Students.First(s => s.UserName == "feeley@penguin.org").Id,
                StatusType = StatusType.Accepted
            };
            StudentPositions.Add(StudentPosition1);

            Int32 Company2Id = Companies.First(c => c.CompanyName == "Adlucent").CompanyId;
            var StudentPosition2 = new AppUserPosition
            {
                AppUserPositionId = 2,
                PositionId = Positions.First(p => p.CompanyId == Company2Id && p.PositionName == "Marketing Intern").PositionId,
                StudentId = Students.First(s => s.UserName == "erynrice@aoll.com").Id,
                StatusType = StatusType.Accepted
            };
            StudentPositions.Add(StudentPosition2);

            Int32 Company3Id = Companies.First(c => c.CompanyName == "Microsoft").CompanyId;
            var StudentPosition3 = new AppUserPosition
            {
                AppUserPositionId = 3,
                PositionId = Positions.First(p => p.CompanyId == Company3Id && p.PositionName == "Corporate Recruiting Intern").PositionId,
                StudentId = Students.First(s => s.UserName == "cmiller@bob.com").Id,
                StatusType = StatusType.Accepted
            };
            StudentPositions.Add(StudentPosition3);

            Int32 Company4Id = Companies.First(c => c.CompanyName == "Deloitte").CompanyId;
            var StudentPosition4 = new AppUserPosition
            {
                AppUserPositionId = 4,
                PositionId = Positions.First(p => p.CompanyId == Company4Id && p.PositionName == "Account Manager").PositionId,
                StudentId = Students.First(s => s.UserName == "estuart@anchor.net").Id,
                StatusType = StatusType.Accepted
            };
            StudentPositions.Add(StudentPosition4);

            Int32 Company5Id = Companies.First(c => c.CompanyName == "Capital One").CompanyId;
            var StudentPosition5 = new AppUserPosition
            {
                AppUserPositionId = 5,
                PositionId = Positions.First(p => p.CompanyId == Company5Id && p.PositionName == "Web Development").PositionId,
                StudentId = Students.First(s => s.UserName == "cbaker@example.com").Id,
                StatusType = StatusType.Accepted
            };
            StudentPositions.Add(StudentPosition5);

            Int32 Company6Id = Companies.First(c => c.CompanyName == "Hilton Worldwide").CompanyId;
            var StudentPosition6 = new AppUserPosition
            {
                AppUserPositionId = 6,
                PositionId = Positions.First(p => p.CompanyId == Company6Id && p.PositionName == "Amenities Analytics Intern").PositionId,
                StudentId = Students.First(s => s.UserName == "erynrice@aoll.com").Id,
                StatusType = StatusType.Accepted
            };
            StudentPositions.Add(StudentPosition6);

            Int32 Company7Id = Companies.First(c => c.CompanyName == "Hilton Worldwide").CompanyId;
            var StudentPosition7 = new AppUserPosition
            {
                AppUserPositionId = 7,
                PositionId = Positions.First(p => p.CompanyId == Company7Id && p.PositionName == "Amenities Analytics Intern").PositionId,
                StudentId = Students.First(s => s.UserName == "tfreeley@minnetonka.ci.us").Id,
                StatusType = StatusType.Accepted
            };
            StudentPositions.Add(StudentPosition7);

            Int32 Company8Id = Companies.First(c => c.CompanyName == "Hilton Worldwide").CompanyId;
            var StudentPosition8 = new AppUserPosition
            {
                AppUserPositionId = 8,
                PositionId = Positions.First(p => p.CompanyId == Company8Id && p.PositionName == "Amenities Analytics Intern").PositionId,
                StudentId = Students.First(s => s.UserName == "limchou@gogle.com").Id,
                StatusType = StatusType.Accepted
            };
            StudentPositions.Add(StudentPosition8);

            Int32 Company9Id = Companies.First(c => c.CompanyName == "Shell").CompanyId;
            var StudentPosition9 = new AppUserPosition
            {
                AppUserPositionId = 9,
                PositionId = Positions.First(p => p.CompanyId == Company9Id && p.PositionName == "Supply Chain Internship").PositionId,
                StudentId = Students.First(s => s.UserName == "ingram@jack.com").Id,
                StatusType = StatusType.Accepted
            };
            StudentPositions.Add(StudentPosition9);

            Int32 Company10Id = Companies.First(c => c.CompanyName == "Shell").CompanyId;
            var StudentPosition10 = new AppUserPosition
            {
                AppUserPositionId = 10,
                PositionId = Positions.First(p => p.CompanyId == Company10Id && p.PositionName == "Supply Chain Internship").PositionId,
                StudentId = Students.First(s => s.UserName == "saunders@pen.com").Id,
                StatusType = StatusType.Accepted
            };
            StudentPositions.Add(StudentPosition10);

            Int32 Company11Id = Companies.First(c => c.CompanyName == "Capital One").CompanyId;
            var StudentPosition11 = new AppUserPosition
            {
                AppUserPositionId = 11,
                PositionId = Positions.First(p => p.CompanyId == Company11Id && p.PositionName == "Financial Analyst").PositionId,
                StudentId = Students.First(s => s.UserName == "johnsmith187@aoll.com").Id,
                StatusType = StatusType.Accepted
            };
            StudentPositions.Add(StudentPosition11);

            Int32 Company12Id = Companies.First(c => c.CompanyName == "Deloitte").CompanyId;
            var StudentPosition12 = new AppUserPosition
            {
                AppUserPositionId = 12,
                PositionId = Positions.First(p => p.CompanyId == Company12Id && p.PositionName == "Accounting Intern").PositionId,
                StudentId = Students.First(s => s.UserName == "cluce@gogle.com").Id,
                StatusType = StatusType.Accepted
            };
            StudentPositions.Add(StudentPosition12);

            Int32 Company13Id = Companies.First(c => c.CompanyName == "Accenture").CompanyId;
            var StudentPosition13 = new AppUserPosition
            {
                AppUserPositionId = 13,
                PositionId = Positions.First(p => p.CompanyId == Company13Id && p.PositionName == "Consultant ").PositionId,
                StudentId = Students.First(s => s.UserName == "estuart@anchor.net").Id,
                StatusType = StatusType.Accepted
            };
            StudentPositions.Add(StudentPosition13);

            Int32 Company14Id = Companies.First(c => c.CompanyName == "Accenture").CompanyId;
            var StudentPosition14 = new AppUserPosition
            {
                AppUserPositionId = 14,
                PositionId = Positions.First(p => p.CompanyId == Company14Id && p.PositionName == "Consultant ").PositionId,
                StudentId = Students.First(s => s.UserName == "wjhearniii@umich.org").Id,
                StatusType = StatusType.Accepted
            };
            StudentPositions.Add(StudentPosition14);

            Int32 Company15Id = Companies.First(c => c.CompanyName == "Deloitte").CompanyId;
            var StudentPosition15 = new AppUserPosition
            {
                AppUserPositionId = 15,
                PositionId = Positions.First(p => p.CompanyId == Company15Id && p.PositionName == "Account Manager").PositionId,
                StudentId = Students.First(s => s.UserName == "j.b.evans@aheca.org").Id,
                StatusType = StatusType.Accepted
            };
            StudentPositions.Add(StudentPosition15);

            Int32 Company16Id = Companies.First(c => c.CompanyName == "Deloitte").CompanyId;
            var StudentPosition16 = new AppUserPosition
            {
                AppUserPositionId = 16,
                PositionId = Positions.First(p => p.CompanyId == Company16Id && p.PositionName == "Account Manager").PositionId,
                StudentId = Students.First(s => s.UserName == "rwood@voyager.net").Id,
                StatusType = StatusType.Pending
            };
            StudentPositions.Add(StudentPosition16);

            Int32 Company17Id = Companies.First(c => c.CompanyName == "Texas Instruments").CompanyId;
            var StudentPosition17 = new AppUserPosition
            {
                AppUserPositionId = 17,
                PositionId = Positions.First(p => p.CompanyId == Company17Id && p.PositionName == "Accounting Rotational Program").PositionId,
                StudentId = Students.First(s => s.UserName == "rwood@voyager.net").Id,
                StatusType = StatusType.Pending
            };
            StudentPositions.Add(StudentPosition17);

            Int32 Company18Id = Companies.First(c => c.CompanyName == "Accenture").CompanyId;
            var StudentPosition18 = new AppUserPosition
            {
                AppUserPositionId = 18,
                PositionId = Positions.First(p => p.CompanyId == Company18Id && p.PositionName == "Consultant ").PositionId,
                StudentId = Students.First(s => s.UserName == "rwood@voyager.net").Id,
                StatusType = StatusType.Pending
            };
            StudentPositions.Add(StudentPosition18);

            builder.Entity<AppUserPosition>().HasData(StudentPositions);

            // Seed Interviews
            List<Interview> Interviews = new List<Interview>();


            Int32 CompanyId1 = Companies.First(c => c.CompanyName == "Adlucent").CompanyId;
            var Interview1 = new Interview
            {
                InterviewId = 1,
                Room = RoomType.Two,
                InterviewDate = new DateTime(2023, 5, 13, 13, 0, 0),
                AppUserPositionId = 1,
                RecruiterId = Recruiters.First(r => r.UserName == "taylordjay@aool.com").Id,
                CreatorId = Recruiters.First(r => r.UserName == "taylordjay@aool.com").Id
            };
            Interviews.Add(Interview1);

            Int32 CompanyId2 = Companies.First(c => c.CompanyName == "Adlucent").CompanyId;
            var Interview2 = new Interview
            {
                InterviewId = 2,
                Room = RoomType.Two,
                InterviewDate = new DateTime(2023, 5, 14, 13, 0, 0),
                AppUserPositionId = 2,
                RecruiterId = Recruiters.First(r => r.UserName == "taylordjay@aool.com").Id,
                CreatorId = Recruiters.First(r => r.UserName == "taylordjay@aool.com").Id
            };
            Interviews.Add(Interview2);

            Int32 CompanyId3 = Companies.First(c => c.CompanyName == "Microsoft").CompanyId;
            var Interview3 = new Interview
            {
                InterviewId = 3,
                Room = RoomType.Two,
                InterviewDate = new DateTime(2023, 5, 15, 13, 0, 0),
                AppUserPositionId = 3,
                RecruiterId = Recruiters.First(r => r.UserName == "louielouie@aool.com").Id,
                CreatorId = Recruiters.First(r => r.UserName == "louielouie@aool.com").Id
            };
            Interviews.Add(Interview3);

            Int32 CompanyId4 = Companies.First(c => c.CompanyName == "Deloitte").CompanyId;
            var Interview4 = new Interview
            {
                InterviewId = 4,
                Room = RoomType.One,
                InterviewDate = new DateTime(2023, 5, 13, 10, 0, 0),
                AppUserPositionId = 4,
                RecruiterId = Recruiters.First(r => r.UserName == "mclarence@aool.com").Id,
                CreatorId = Recruiters.First(r => r.UserName == "mclarence@aool.com").Id
            };
            Interviews.Add(Interview4);

            Int32 CompanyId5 = Companies.First(c => c.CompanyName == "Capital One").CompanyId;
            var Interview5 = new Interview
            {
                InterviewId = 5,
                Room = RoomType.Two,
                InterviewDate = new DateTime(2023, 5, 16, 14, 0, 0),
                AppUserPositionId = 5,
                RecruiterId = Recruiters.First(r => r.UserName == "smartinmartin.Martin@aool.com").Id,
                CreatorId = Recruiters.First(r => r.UserName == "smartinmartin.Martin@aool.com").Id
            };
            Interviews.Add(Interview5);

            Int32 CompanyId6 = Companies.First(c => c.CompanyName == "Hilton Worldwide").CompanyId;
            var Interview6 = new Interview
            {
                InterviewId = 6,
                Room = RoomType.One,
                InterviewDate = new DateTime(2023, 4, 1, 9, 0, 0),
                AppUserPositionId = 6,
                RecruiterId = Recruiters.First(r => r.UserName == "yhuik9.Taylor@aool.com").Id,
                CreatorId = Recruiters.First(r => r.UserName == "yhuik9.Taylor@aool.com").Id
            };
            Interviews.Add(Interview6);

            Int32 CompanyId7 = Companies.First(c => c.CompanyName == "Hilton Worldwide").CompanyId;
            var Interview7 = new Interview
            {
                InterviewId = 7,
                Room = RoomType.One,
                InterviewDate = new DateTime(2023, 4, 1, 10, 0, 0),
                AppUserPositionId = 7,
                RecruiterId = Recruiters.First(r => r.UserName == "yhuik9.Taylor@aool.com").Id,
                CreatorId = Recruiters.First(r => r.UserName == "yhuik9.Taylor@aool.com").Id
            };
            Interviews.Add(Interview7);

            Int32 CompanyId8 = Companies.First(c => c.CompanyName == "Hilton Worldwide").CompanyId;
            var Interview8 = new Interview
            {
                InterviewId = 8,
                Room = RoomType.Four,
                InterviewDate = new DateTime(2023, 4, 2, 15, 0, 0),
                AppUserPositionId = 8,
                RecruiterId = Recruiters.First(r => r.UserName == "yhuik9.Taylor@aool.com").Id,
                CreatorId = Recruiters.First(r => r.UserName == "yhuik9.Taylor@aool.com").Id
            };
            Interviews.Add(Interview8);

            Int32 CompanyId9 = Companies.First(c => c.CompanyName == "Shell").CompanyId;
            var Interview9 = new Interview
            {
                InterviewId = 9,
                Room = RoomType.One,
                InterviewDate = new DateTime(2023, 5, 10, 9, 0, 0),
                AppUserPositionId = 9,
                RecruiterId = Recruiters.First(r => r.UserName == "elowe@netscrape.net").Id,
                CreatorId = Recruiters.First(r => r.UserName == "elowe@netscrape.net").Id
            };
            Interviews.Add(Interview9);

            Int32 CompanyId10 = Companies.First(c => c.CompanyName == "Shell").CompanyId;
            var Interview10 = new Interview
            {
                InterviewId = 10,
                Room = RoomType.One,
                InterviewDate = new DateTime(2023, 5, 10, 11, 0, 0),
                AppUserPositionId = 10,
                RecruiterId = Recruiters.First(r => r.UserName == "elowe@netscrape.net").Id,
                CreatorId = Recruiters.First(r => r.UserName == "elowe@netscrape.net").Id
            };
            Interviews.Add(Interview10);

            Int32 CompanyId11 = Companies.First(c => c.CompanyName == "Capital One").CompanyId;
            var Interview11 = new Interview
            {
                InterviewId = 11,
                Room = RoomType.Three,
                InterviewDate = new DateTime(2023, 5, 16, 15, 0, 0),
                AppUserPositionId = 11,
                RecruiterId = Recruiters.First(r => r.UserName == "or@aool.com").Id,
                CreatorId = Recruiters.First(r => r.UserName == "or@aool.com").Id
            };
            Interviews.Add(Interview11);

            Int32 CompanyId12 = Companies.First(c => c.CompanyName == "Deloitte").CompanyId;
            var Interview12 = new Interview
            {
                InterviewId = 12,
                Room = RoomType.Four,
                InterviewDate = new DateTime(2023, 5, 16, 11, 0, 0),
                AppUserPositionId = 12,
                RecruiterId = Recruiters.First(r => r.UserName == "nelson.Kelly@aool.com").Id,
                CreatorId = Recruiters.First(r => r.UserName == "nelson.Kelly@aool.com").Id
            };
            Interviews.Add(Interview12);

            Int32 CompanyId13 = Companies.First(c => c.CompanyName == "Accenture").CompanyId;
            var Interview13 = new Interview
            {
                InterviewId = 13,
                Room = RoomType.Three,
                InterviewDate = new DateTime(2023, 6, 5, 14, 0, 0),
                AppUserPositionId = 13,
                RecruiterId = Recruiters.First(r => r.UserName == "michelle@example.com").Id,
                CreatorId = Recruiters.First(r => r.UserName == "michelle@example.com").Id
            };
            Interviews.Add(Interview13);

            Int32 CompanyId14 = Companies.First(c => c.CompanyName == "Accenture").CompanyId;
            var Interview14 = new Interview
            {
                InterviewId = 14,
                Room = RoomType.Three,
                InterviewDate = new DateTime(2023, 6, 5, 16, 0, 0),
                AppUserPositionId = 14,
                RecruiterId = Recruiters.First(r => r.UserName == "toddy@aool.com").Id,
                CreatorId = Recruiters.First(r => r.UserName == "toddy@aool.com").Id
            };
            Interviews.Add(Interview14);

            builder.Entity<Interview>().HasData(Interviews);
        }
    }

}