using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Neerogilksample.Data.Enums;
using Neerogilksample.Data.Static;
using Neerogilksample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neerogilksample.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                  
                //Doctor
                if (!context.Doctors.Any())
                {
                    context.Doctors.AddRange(new List<Doctor>()
                    {
                        new Doctor()
                        {
                            FirstName = "Kamal",
                            LastName = "Perera",
                            ProfilePictureURL = "data:image/jpeg;base64,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",
                            FullName = "Kamal Perera",
                            ContactNumber = "0715423652",
                            EmergencyContactNumber = "0714542589",
                            NIC= 14,
                            //Birthday=1988,02,14,
                            RegNumber = "14758D",
                            GraduatedUniversity = "Colombo University",
                            GraduatedYear=1988,
                            Degree = "MBBS",
                            DegreeSpecialization="Nurone"

                        },
                             new Doctor()
                        {
                            FirstName = "Pasan",
                            LastName = "Gunasekara",
                            FullName = "Pasan Gunasekara",
                            ProfilePictureURL = "data:image/jpeg;base64,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",
                            ContactNumber = "0715423652",
                            EmergencyContactNumber = "0714542589",
                            NIC= 14,
                            //Birthday=1988,02,14,
                            RegNumber = "14758D",
                            GraduatedUniversity = "Colombo University",
                            GraduatedYear=1988,
                            Degree = "MBBS",
                            DegreeSpecialization="Nurone"

                        },
                            new Doctor()
                        {
                            FirstName = "Sunil",
                            LastName = "Perera",
                            FullName = "Sunil Perera",
                            ProfilePictureURL = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAoHCBESEhESERIREhISEhIYEhIRERESEhEYGBQaGRgUGBgcIS4lHB4rJBgYJjgmKy8xNTU1GiQ7QDs0Py40NTEBDAwMEA8QGhIRGjEkISE2NDExNDQ0NDQ1MTQ2NDE0MTQ0MTE0NDQxNDQ0MTE0NDExNDQ0NDQ0NDQxNDE0NDE0NP/AABEIALcBEwMBIgACEQEDEQH/xAAbAAADAAMBAQAAAAAAAAAAAAAAAQIDBAUGB//EADsQAAEDAgMFBgQFAwMFAAAAAAEAAhEDIQQSMQVBUWFxBhMigZGhMlKxwUJictHwFIKSM8LhI0NTorL/xAAaAQEBAAMBAQAAAAAAAAAAAAAAAQMEBQIG/8QAIxEBAQEAAQQCAgMBAAAAAAAAAAECEQMEITESQSJRMmFxBf/aAAwDAQACEQMRAD8A2wqCkKgt9xFBNIJoKCYSTCCk0k2iVFMJhSqCKpCEIBNJNRQmhc7bW1qeFZmd4nn4KYN3czwHNS2TzVzm6vEbleuymMz3Bo4uMBa9Ta9BjQ41GQdPELr5xiMXWxVQveHPeD4abcxazk1g+uq6FHs5iqrS40nsMeEkjX9O4LDrryN3PZ2zzXusJtGlV+Coxx4Bwn0W0vmlfZWLw5l9J4y3FSmS6OdrhdrYXamSKdZwc0mBU3tP5o1HP14q462b7eOp2msTmeXsUIB4IWZqEkU0lUSUBCRQJykqipKIgqSrKgqoRUlUVJQSQFBaOAVFS4qhQOCEpQgzhUFIVBQMJpJoGqCkK2BAwqJUngkoqwgJBEoKlUoCcoqgmpCaCMRXbTY+o74WNJPkNF85xTqmKrAu+Oo603DGg7un16r1vazE5KTKY1q1APJoLvqAvM7CBqVnv/AyGtjraFq9fV9R0uy6c/lft7jYmzqdNgaxoHEx4nHiTvXoadIBeXbtN9KD3BLN0PZn/wAV3dm7Wp1x4Q5pGrXCHBaXH3XWv9NupRaV4jtZ2eaQ+vRaBUbeoxogVABcx80esL1eP2xRo2fmLjo1jS5x8gtB+ONQH/pVGNOjnZfdsyE9XmPNnM4ridl9oFze5eZhuam4nVu9vlI8ui9CvnOAxZpVw3QsxDmxy8Uj+cV9Fa6QDxC6PQ18s+fpw+76cxvmeqEimUlmaqSkU0igRUlUVBVRJUlUUiiJKQEqoUuO4IMblDlRUlUY0KkIjYCoKArCKaaQTCgYTCSaBppIQUE1KaKaJSQEDBVgqEAqDyfbYlz6Dc2UNDiSIsLHf0Wr2Mw5cyo2dX2PlZZ+18uqNj8Ik84Mx7LLsg92+RGWoA5pbpEaQtDrXnVdztc8dPNbZ2bju8JFTIJhsU8wLYOs3Oo37l3sPh+7qU3cSQfCBItEgWnXSAulgK4cLrmbUxeSq1wp1HtBbdgBAB1JvuWva35PI2vgKjy91J5a8m3ga8DhY7tfVc7Z2zsWKmao8FmXxSwNM8oAt1k8138Hiy573d29rLQXRDhGrbz6ws+OrjKcqc/SWeXynadICu/wgOGJqHNeXtJvN4scu5fQdmPzUmO/LHovObUwmaqBM5Gtn9b3OcR/8+oXX2I85Mp8vuFt9vrzY5nfY5zLPp03KSqKkrcckkigpFEIqSqKkqokobzQVJQDysZVlQVRBUlUVJQJCSEGcKgpCpgQMJpFOVAwmkEwgcoSQgpEpIAQMK9OqkmFGZFXKJUgpPfAKEeR21iA5zyBMTHkYI91pYKvlqUHBzhTc4scwmzXO+EjheAus2m0gzq5xI6EyPa6852gHdse0G7nNiLZYvbpPuuXfO6+gxxnE4fScECWkB0GLE3C1cNWxAqFlVzQJsacS7yeQB6lcTs3thzqVPvLuLR49A62/gV6qm6k+C6D91444rZzrmMLqmIdUa2m8NZHiNTK5w4wGGB/kr2riRRovqOMljHG1pMWA6mFtuqUqbZEDkvBdvcW8toCSKdR7iW/NlALZ5Xn0STnTzvXErfpEim214JH5srpueJ/dbmz8UJdMi8n8s6npMrQL4LBBLXU2EFusADxs5gyY581uYZ8udOUl7CCW/C+1nDrwXrpXjbX685xXdY+ZB1br+6orFQaB/i0egWQldOenC3OKRSKZSK9PJKUykURJUlUVBQIqSUypKokqXKipKIlClCo2mhVm4KXO4ICiqQhCATSlEqCpTUSnKByiVJKJVFZlJKRcpLkFytLGPL/AA/hEW+Y8Fne+Ou5Xg8C+pJY0lzTAmQ2SOMXsAsPW1xOJ7bXbdL5a516jh1gWZ3uiQI5AnQDoF5naeFqVWggHKNXcSdw529ivorez73XrFpg/wCnTBj+5x+LyW7svYzTXLXAZabbiLNc8WEdDPktLONW811brMkkeP2Ps0toMYdWiPNblLCvB1cOhIXY/pTTe5rhBBII6LYbTETErBbW1OGjhsHcFxLupJXL7Z7KdWp0yxhf3bnFwbrlLTJHSAvU0wByW/sijmqZvwsBk9QQB9fResS3UeN2TNfOtk4kd21hJD6RlhdZwjSR7eh3rpd7TdDmjKD8QAs02nou12p2C1zs9NrWF0ZCABlfvHCCN2i88/CV6YILCyoHCR4hIi8R0HHXesm+nc3mMWd51PLtYTE5h4hlI4xB81skrz+Gx73h8tcHMLcwNwQea6+Br52TwJHK3D2W10Orb+Op5czu+jM/lm+GzKAEBJzuC2WiHRuUFBKklAFSSgpEqiSkUypKIRUoKkoqsoQsaFU5ZwqCgJhRVynKlNA0KZTCIYKJQ4QplFVKklKVJKIZcnh6LnvDG6niSAFicV1+z9DM4uNpJa08CAD9/ZTV4j30s/LUjq7P2TTplstDnOHxuEmRqL6cfIro4gFrYZZxsDwtJPoCmx/hOYeOmQTzHzDyn3WZ4Flr10syT016VM03Oa2MkZvETm5md60thSWmoWumtUe6fDAEwBrMCOC3dokim92/u6g9GE/Za2zXubRpOaMzMgzNHxNvOYcddEeuWfHYYOBeGNc4ayBcei0qbB8tMdBP7Lr0qjXDM0gjl9CtDFU8jraG4U4n6edc++Q51pMW4hb+GZDBYAuEnzXPpszENOhN+gW9jMUykx1R5hrfMngAN5KGXO27IpXAjvGQQb67xuW+WMebiROjmkQRO4hcfEUK2IbmqVG0wYLKEA5BqM5+bytuWbAYuoyoKVctcXtc6nUaZD41aTxH81tV5ZcTsihVBLqbPFMkANJHUXXIxGxO4aTSk0xctOrb3IO9emboE3sBaRxt7JPF5edz5Z+NeKc+VMrLj6Ap1HMGkNI5S0GPdYVsRzNSy2UEpFBKRVAVJTSKIkqSmVJQIqSmVJKoSEkIMwKalMKCpTlJCBgKtOqTiNyiUVRckSplCICVJKCVJKqE5y9NsKllpuB3OGcfiY78Lxy3eS83hKfeVKbPme0e69RgnBlXxnLUPhf8tQceqx7v02u2z707BZOusEGNHNOsK6PwtnWI6pNZFt27kikdeTnfusLdRiG52Zfma8erY+65/ZmrNCn+mD5OIXSafC081xuz/hNen/469QD9Lrj7oOtXwpkvpnI/f8r+ThvWB2IFQd28ZKjbhp0fxynf0XQBWDG4VlQXF05/ZY1sLUAcd5AEAamVi7RUpw73FzQW5XHNdoAcPDqOS28FTABdvm/pH0Wt2jwwq4PEMdP+m42MGWeMe7QhJxG+wQIIExfrvK423aJnDvpiHNr09LDxW+sLtG9xvXL2/h3PohrXFju/wxDhMiKzOHHTzRXTbaJ0Auk9xjS5OiHGw5uH1sqMCSf5yRHndvYUgtqTMnK7mTJB9j7Ljhd/tG13dsO7PmdytlH1A8158FZs+nP6843TQUSkSvbCCpTSJjqglygpkqSVQFQUypKAQpQgzApqZTBUFShKUSgZKUpEpEqoqUiVMpEoAlQ5yHFY3ORGxga5p1GVAJ7twceg1+q9u1lOrDw2WVBJB3HivNbAfTyva4EPLgcwO6LNjrK9ZSolkeIEQsO75dDt5xn/AFdBpb4SS4R4XHUjgeYV8Us9724Ic6M3ISsbYRSPg6Oj3XJwgyY2u3dVpseOZbI/ddWl+McYI/nkuVtY93Vw1bcHFjz+Vw/4jzQdxhVOWNpVSiopiJ6qqjA5rmnRzXA+YhDY+6ReABJAkwJQa+yqhfQpEmXBga/9bPA//wBmlG0PhYONfD+1Vrj7ArXwLxTqVKbrU6jy+k4/DLvjZ6jNzzO4K8dXZ3lBpcIa573GREhhYxh5kvn+xFbh1aOF/wCeqczfcsebUyDY6XHD7hZALAHhojy52170arnWGUBg89f5wXkgV67HsNTMPwtBHUkR7Lx8RY6jVZun6aXdTzKyApkqJRK9tVbiIssRKCUiqvIlSU0iiJKkpkqSUUkJSmiMkpgpOgdUpRVyglTKJQOUilKRRASpJQSoJRA4pcymRAlYHuQb+y3E1IHL6r6BhXBzRMaXXz/s63Niabfmn2E/Ze7bh73JtwWHqe3Q7a/gzV2S0hpgkGDrlMarztPGV6bwyoZy2IJs5pHvxB6r0TGgLHi8DTq5c4Mt+EgkEeYWDWbfVbnT1nPM1OZWrh8UCQZ3QVGIfSqkU6phmdmZw1aQ4EHleJPDW0q37JE+B7mnfPiELBT2VWp1e9pVmyfiY+mXNPA2dY81ZzZ5TXxl8OrXwBY8VKbyaYyhzXGQ+TBg8pBnkQiq+NNdy1quIxLnAVSzINBTDgCeJnVZCHGDwVzLPbzb+l0HgtMTMwSeMAp16bHth4BAvB0WN7zu5KHudGkngqHVwdOoJaMoi4Fh5hYMPgGUwQwRJud5Sfi8nhIy7yD1WF+0XHT2U1qZ917zjWvUdKmLgevl/wAkLM8zZcP+tqbrbvC2/S60MTiqxPhpVDf4nVGj/dZYr1s/TLnt9X3eHp6lPwndqvG7UpZKz26Xkf3Cfuuph8ZiwA7un1Gb252Pno4EkLR29VD67iPlYNxjwiRbqs/Q18q0e96fwzPMvlz00ghbLmgpFBQUUiVBKoqSiJKkpkIiLlFLKhLOU0BKamU5QNOVMolA0pSlSSiGSpKZKglBLljcqcVicURn2fXNOtTeDBDvrZfRcJWcQSN8XXy4vggjcQfRfRNmYlvdMM2IGl1i6kbva68WOu0HeUPqBu/9z0WmcW51mDKPmdc+QV0gBe7nHVxWJtNljjvty3qiViz+aReUVmUvI/mqwjOdLLKylGqBtCYumUMCLGjtekCWEDc77LnilHFZ+0Fd7XsDKb3gNcSWNLoJI1joua3FVT/2a3+D/wBlrbzbq+G309SZnlsvIGrojjotXEd7BLK7OQdTDh7ELH/UPPx0nxvBbBHUG6xUKeEzZcgYN5DcpbwMb1j+F+/DNNzjx5Y2bSq0TL2gSbvbLqb/ANQ3LFicSKj3PFs0GOFhZb2P2RVa2aTxVYR8LoJg7wd4XLcwtOUgAiAQ3QGLhbXb51nVl9Od/wBDWNYlnvlSEpRK3HIBKRKCUiUCKkpkqCVRdonesTigqSUClCUoQVKcqJTlBUpSlKUoiiUiU4tdYyUDJUEpEqSUQOKwuKpxWJxQS4rs7L23Tp0wx5e0tEAhuZrhu5grhPKwvKXMvt6xvWbzHtcLt5rz4C4j8zbfvvXVobYabOy+RH0K8n2fw2am5/M/VXjYsJHNYbmcujjVuZb9vbU9oU+PqtuniqZ3iea+eMfWbHd546HLH91lsM2lWBgtafIg+y8/Fk5fQP6lnEI74cV4XD7WquqMpmmG53ZZzE66EecLrPp12nd7/upwcvS5xxTa8LypfiBvTpVaxdcwN6cHL076gLoDgDlH1KxVKVTc/wBlho4VjgJcZ4zdY8TjKdAQamY7mkyVFKr3w1DXjg4SuTj8AKlzT7tw/E15HsZTxPaGo6RTYOrpAXFxeJrvvUc7pPh9l6mefFedbuJzPp18PjDQp92ameC4iRJv+GeH7rjvqZnF3EkrXDlQcsuczM8NDrdbXUvlllEqJRK9sKyVJKmUpQMlSSkSkShyCVJKCVJKAlCmU0ACnmQhApVxGqEIqHOlQXIQiJLlDnIQiMbnLE5yEIjE9yx02Z3tbMZnNbPCTEoQl9LPce92RsoU6Qpl5cDckDLM3jet7+ipt0a0HjEn1SQtfl1pJMsL6QM9QsbcAIlCFVYqmHALHACWPYY6OB1XXq7RB/BHmhClGo/GtOgj1WucS53wyekD6oQqKrYar8wHQyUm7MFibneTqUIURm/ogOC0NpUopvMcPqEIVntN/wAL/jiNKyApIWdyjBTzJoQMaXWOUIRaCVJKEIiSoJQhBMoQhB//2Q==",
                            ContactNumber = "0715423652",
                            EmergencyContactNumber = "0714542589",
                            NIC= 14,
                            //Birthday=1988,02,14,
                            RegNumber = "14758D",
                            GraduatedUniversity = "Colombo University",
                            GraduatedYear=1988,
                            Degree = "MBBS",
                            DegreeSpecialization="Nurone"

                        },
                             new Doctor()
                        {
                            FirstName = "Sunil",
                            LastName = "Perera",
                            FullName="Sunil Perera",
                            ContactNumber = "0715423652",
                            EmergencyContactNumber = "0714542589",
                            NIC= 14,
                            //Birthday=1988,02,14,
                            RegNumber = "14758D",
                            GraduatedUniversity = "Colombo University",
                            GraduatedYear=1988,
                            Degree = "MBBS",
                            DegreeSpecialization="Nurone"

                        },
                              new Doctor()
                        {
                            FirstName = "Sunil",
                            LastName = "Perera",
                            FullName = "Sunil Perera",
                            ContactNumber = "0715423652",
                            EmergencyContactNumber = "0714542589",
                            NIC= 14,
                            //Birthday=1988,02,14,
                            RegNumber = "14758D",
                            GraduatedUniversity = "Colombo University",
                            GraduatedYear=1988,
                            Degree = "MBBS",
                            DegreeSpecialization="Nurone"

                        }

                    });
                    context.SaveChanges();
                }

            //    //DigitalPrescription
            //    if (!context.DigitalPrescriptions.Any())
            //    {
            //        context.DigitalPrescriptions.AddRange(new List<DigitalPrescription>()
            //        {
            //            new DigitalPrescription()
            //            {
            //                PatientName = "Pasan Perera",
            //                PatientAddress ="Sri Lanka",
            //                ContactNumber = "0714141425",
            //                Description = "He has huge headache",
            //                //Birthday
            //                BirthDay = DateTime.Now.AddDays(-10),
            //                Age = 15,
            //                //DateofIssue
            //                Dateofissue = DateTime.Now.AddDays(-10),
            //                DoctorId = 1

            //            },
            //              new DigitalPrescription()
            //            {
            //                PatientName = "Sam Perera",
            //                PatientAddress = "Sri Lanka",
            //                ContactNumber = "0714141425",
            //                Description = "He has huge headache",
            //                //Birthday
            //                BirthDay = DateTime.Now.AddDays(-10),
            //                Age = 15,
            //                //DateofIssue
            //                Dateofissue = DateTime.Now.AddDays(-10),
            //                DoctorId = 2

            //            },
            //               new DigitalPrescription()
            //            {
            //                CustomerName = "Pasan Perera",
            //                //Birthday
            //                BirthDay = DateTime.Now.AddDays(-10),
            //                Age = 15,
            //                //DateofIssue
            //                Dateofissue = DateTime.Now.AddDays(-10),
            //                DoctorId = 1

            //            }

            //        });
            //        context.SaveChanges();

            //    }

            //    //GeneralMedicineProducts
            //    if (!context.GeneralMedicineProducts.Any())
            //    {
            //        context.GeneralMedicineProducts.AddRange(new List<GeneralMedicineProducts>()
            //        {
            //            new GeneralMedicineProducts()
            //            {
            //               Name = "Sirup",
            //               ManufacturedCompanyName = "Sampath",
            //               ProductPictureURL = "https://static-01.daraz.lk/p/236c3232c09b7697bfaf8dfbf9928cb5.jpg",
            //               ManufacturedDate = DateTime.Now.AddDays(-10),
            //               ExpirationDate = DateTime.Now.AddDays(-10),
            //               DrugProductCategory = DrugProductCategory.Liquid,
            //               DigitalPrescriptionId = 17,
            //            },
            //                new GeneralMedicineProducts()
            //            {
            //               Name = "Panadol",
            //               ProductPictureURL="https://i-cf65.ch-static.com/content/dam/cf-consumer-healthcare/panadol/en_ie/ireland-products/panadol-tablets/MGK5158-GSK-Panadol-Tablets-455x455.png?auto=format",
            //               ManufacturedCompanyName = "Sampath",
            //               ManufacturedDate = DateTime.Now.AddDays(-10),
            //               ExpirationDate = DateTime.Now.AddDays(-10),
            //               DrugProductCategory = DrugProductCategory.Liquid,
            //               DigitalPrescriptionId = 26,
            //            },
            //                    new GeneralMedicineProducts()
            //            {
            //               Name = "Paracitamol",
            //               ProductPictureURL= "https://i-cf65.ch-static.com/content/dam/global/panadol/en_LK/760x820/300x300Panadol.png?auto=format",
            //               ManufacturedCompanyName = "Sathsara",
            //               ManufacturedDate = DateTime.Now.AddDays(-10),
            //               ExpirationDate = DateTime.Now.AddDays(-10),
            //               DrugProductCategory = DrugProductCategory.Liquid,
            //               DigitalPrescriptionId = 10,
            //            }

            //        });
            //        context.SaveChanges();
            //    }
            //    //NewGeneralMedicineProducts
            //    if (!context.GeneralMedicines.Any())
            //    {
            //        context.GeneralMedicines.AddRange(new List<GeneralMedicines>()
            //        {
            //            new GeneralMedicines()
            //            {
            //               Name = "Sirup",
            //               ManufacturedCompanyName = "Sampath",
            //               ProductPictureURL = "https://static-01.daraz.lk/p/236c3232c09b7697bfaf8dfbf9928cb5.jpg",
            //               ManufacturedDate = DateTime.Now.AddDays(-10),
            //               ExpirationDate = DateTime.Now.AddDays(-10),
            //               DrugProductCategory = DrugProductCategory.Liquid,

            //            },
            //                new GeneralMedicines()
            //            {
            //               Name = "Panadol",
            //               ProductPictureURL="https://i-cf65.ch-static.com/content/dam/cf-consumer-healthcare/panadol/en_ie/ireland-products/panadol-tablets/MGK5158-GSK-Panadol-Tablets-455x455.png?auto=format",
            //               ManufacturedCompanyName = "Sampath",
            //               ManufacturedDate = DateTime.Now.AddDays(-10),
            //               ExpirationDate = DateTime.Now.AddDays(-10),
            //               DrugProductCategory = DrugProductCategory.Liquid,

            //            },
            //                    new GeneralMedicines()
            //            {
            //               Name = "Paracitamol",
            //               ProductPictureURL= "https://i-cf65.ch-static.com/content/dam/global/panadol/en_LK/760x820/300x300Panadol.png?auto=format",
            //               ManufacturedCompanyName = "Sathsara",
            //               ManufacturedDate = DateTime.Now.AddDays(-10),
            //               ExpirationDate = DateTime.Now.AddDays(-10),
            //               DrugProductCategory = DrugProductCategory.Liquid,

            //            }

            //        });
            //        context.SaveChanges();
            //    }
            //    //DeliveryPerson
            //    if (!context.DeliveryPersons.Any())
            //    {
            //        context.DeliveryPersons.AddRange(new List<DeliveryPerson>()
            //        {
            //           new DeliveryPerson()
            //           {
            //               FirstName = "Janul",
            //               LastName = "Perera",
            //               FullName = "Janul Perera",
            //               ProfilePictureURL = "https://image.shutterstock.com/image-photo/photo-document-passport-id-mature-260nw-1178817271.jpg",
            //               //IdpicturefrontURL = "https://image.shutterstock.com/image-photo/photo-document-passport-id-mature-260nw-1178817271.jpg",
            //               //IdpicturebackURL = "https://image.shutterstock.com/image-photo/photo-document-passport-id-mature-260nw-1178817271.jpg",
            //               //LicenseFrontPictureURL = "https://image.shutterstock.com/image-photo/photo-document-passport-id-mature-260nw-1178817271.jpg",
            //               //LicenseBackPictureURL = "https://image.shutterstock.com/image-photo/photo-document-passport-id-mature-260nw-1178817271.jpg",
            //               //PoliceReportsURL = "https://image.shutterstock.com/image-photo/photo-document-passport-id-mature-260nw-1178817271.jpg",
            //               Birthday = DateTime.Now.AddDays(-10),
            //               ContactNumber = "0714145829",
            //               EmergencyContactNumber = "0745526931",
            //               NIC = "7699525415V",
            //               ReceivedDateLicense = DateTime.Now.AddDays(-10),
            //               ExpirationDate = DateTime.Now.AddDays(-10)
            //           },
            //             new DeliveryPerson()
            //           {
            //               FirstName = "Nima;",
            //               LastName = "Perera",
            //               //Birthday
            //               ProfilePictureURL = "https://image.shutterstock.com/image-photo/photo-document-passport-id-mature-260nw-1178817271.jpg",
            //               //IdpicturefrontURL = "https://image.shutterstock.com/image-photo/photo-document-passport-id-mature-260nw-1178817271.jpg",
            //               //IdpicturebackURL = "https://image.shutterstock.com/image-photo/photo-document-passport-id-mature-260nw-1178817271.jpg",
            //               //LicenseFrontPictureURL = "https://image.shutterstock.com/image-photo/photo-document-passport-id-mature-260nw-1178817271.jpg",
            //               //LicenseBackPictureURL = "https://image.shutterstock.com/image-photo/photo-document-passport-id-mature-260nw-1178817271.jpg",
            //               //PoliceReportsURL = "https://image.shutterstock.com/image-photo/photo-document-passport-id-mature-260nw-1178817271.jpg",
            //               FullName = "Nima Perera",
            //               Birthday= DateTime.Now.AddDays(-10),
            //               ContactNumber = "0779562231",
            //               EmergencyContactNumber = "0745526931",
            //               NIC = "7299525415V",
            //               //ReceivedDate License
            //               ReceivedDateLicense = DateTime.Now.AddDays(-10),
            //               //Expiration License
            //               ExpirationDate = DateTime.Now.AddDays(-10)
            //           },
            //               new DeliveryPerson()
            //           {
            //               FirstName = "Pasan",
            //               LastName = "Perera",
            //               //Birthday
            //               FullName = "Pasan Perera",
            //               ProfilePictureURL = "https://image.shutterstock.com/image-photo/passport-photo-cute-well-dressed-260nw-1816206689.jpg",
            //               //IdpicturefrontURL = "https://image.shutterstock.com/image-photo/photo-document-passport-id-mature-260nw-1178817271.jpg",
            //               //IdpicturebackURL = "https://image.shutterstock.com/image-photo/photo-document-passport-id-mature-260nw-1178817271.jpg",
            //               //LicenseFrontPictureURL = "https://image.shutterstock.com/image-photo/photo-document-passport-id-mature-260nw-1178817271.jpg",
            //               //LicenseBackPictureURL = "https://image.shutterstock.com/image-photo/photo-document-passport-id-mature-260nw-1178817271.jpg",
            //               //PoliceReportsURL = "https://image.shutterstock.com/image-photo/photo-document-passport-id-mature-260nw-1178817271.jpg",
            //               Birthday = DateTime.Now.AddDays(-10),
            //               ContactNumber = "0765254471",
            //               EmergencyContactNumber = "0745526931",
            //               NIC = "5899525415V",
            //               //ReceivedDate License
            //               ReceivedDateLicense = DateTime.Now.AddDays(-10),
            //               //Expiration License
            //               ExpirationDate = DateTime.Now.AddDays(-10)
            //           }
            //        });
            //        context.SaveChanges();
            //    }

            //    //Pharmacy
            //    if (!context.Pharmacies.Any())
            //    {
            //        context.Pharmacies.AddRange(new List<Pharmacy>()
            //        {
            //            new Pharmacy()
            //            {
            //                PharmacyName = "ABC Pharmacy",
            //                OwnerFirstName = "Kamal",
            //                OwnerLastName = "Gunasekara",
            //                OwnerFullName = "Kamal Gunasekara",
            //                OwnersNIC = "8874586632V",
            //                ContactNumber="0714578585",
            //                LocatedNearsetCity = "Nugegoda",
            //                Logo = "https://static.vecteezy.com/system/resources/previews/004/573/854/original/pharmacy-capsule-medicine-logo-logo-of-pill-atom-planet-pharmaceutical-icons-icon-symbol-template-free-vector.jpg",
            //                EmergencyContactNumber="0714578585",
            //                PharmacyRegisteredNumber = "4514ph",
            //                //Registration Date
            //                RegistrationDate = DateTime.Now.AddDays(-10),
            //                GeoCoordinatesGoogleLocation = "4171s7s1s7s1s7s1s7s1s7",
            //                //GeoCoordinatesGoogleLocation
                          
            //            },
            //              new Pharmacy()
            //            {
            //                PharmacyName = "TUV Pharmacy",
            //                OwnerFirstName = "Nimal",
            //                OwnerLastName = "Perera",
            //                Logo = "https://thumbs.dreamstime.com/b/pharmacy-logo-template-modern-abstract-button-shape-emblem-medical-service-cross-abstract-decoration-medical-logotype-192166171.jpg",
            //                OwnerFullName = "Nimal Perera",
            //                OwnersNIC = "6674586632V",
            //                ContactNumber="0714578585",
            //                LocatedNearsetCity = "Nugegoda",
            //                WhatsAppNumber = "940713601428",
            //                PharmacyRegisteredNumber = "4754ph",
            //                EmergencyContactNumber="0714578585",
            //                //Registration Date
            //                RegistrationDate = DateTime.Now.AddDays(-10),
            //                GeoCoordinatesGoogleLocation = "4171s7s1s7s1s7s1s7s1s7"
            //                //GeoCoordinatesGoogleLocation

            //            },
            //                new Pharmacy()
            //            {
            //                PharmacyName = "EGF Pharmacy",
            //                OwnerFirstName = "Sunimal",
            //                OwnerLastName = "Premathilake",
            //                LocatedNearsetCity = "Kottawa",
            //                WhatsAppNumber = "940713601428",
            //                OwnerFullName = "Sunimal Premathilake",
            //                Logo = "data:image/png;base64,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",
            //                OwnersNIC = "7474586632V",
            //                PharmacyRegisteredNumber = "7484ph",
            //                EmergencyContactNumber="0714578585",
            //                RegistrationDate = DateTime.Now.AddDays(-10),
            //                ContactNumber="0714578585",
            //                GeoCoordinatesGoogleLocation = "4171s7s1s7s1s7s1s7s1s7"

            //            },
            //              new Pharmacy()
            //            {
            //                PharmacyName = "EGF Pharmacy",
            //                OwnerFirstName = "Sunimal",
            //                OwnerLastName = "Premathilake",
            //                LocatedNearsetCity = "Kottawa",
            //                WhatsAppNumber = "940713601428",
            //                OwnerFullName = "Sunimal Premathilake",
            //                OwnersNIC = "7474586632V",
            //                PharmacyRegisteredNumber = "7484ph",
            //                EmergencyContactNumber="0714578585",
            //                RegistrationDate = DateTime.Now.AddDays(-10),
            //                ContactNumber="0714578585",
            //                GeoCoordinatesGoogleLocation = "4171s7s1s7s1s7s1s7s1s7"

            //            },

            //              new Pharmacy()
            //            {
            //                PharmacyName = "EGF Pharmacy",
            //                OwnerFirstName = "Sunimal",
            //                OwnerLastName = "Premathilake",
            //                LocatedNearsetCity = "Homagama",
            //                WhatsAppNumber = "940713601428",
            //                OwnerFullName = "Sunimal Premathilake",
            //                OwnersNIC = "7474586632V",
            //                PharmacyRegisteredNumber = "7484ph",
            //                EmergencyContactNumber="0714578585",
            //                RegistrationDate = DateTime.Now.AddDays(-10),
            //                ContactNumber="0714578585",
            //                GeoCoordinatesGoogleLocation = "4171s7s1s7s1s7s1s7s1s7",

            //            }


            //        });
            //        context.SaveChanges();
            //    }
            //    // Many to Many Relationships

            //    //Doctors_Pharmacies

            //    if (!context.DoctorsPharmacies.Any())
            //    {
            //        context.DoctorsPharmacies.AddRange(new List<Doctor_Pharmacy>()
            //        {
            //            new Doctor_Pharmacy()
            //            {
            //                DoctorId = 1,
            //                PharmacyId = 5
            //            },
            //             new Doctor_Pharmacy()
            //            {
            //                DoctorId = 2,
            //                PharmacyId = 4
            //            },
            //              new Doctor_Pharmacy()
            //            {
            //                DoctorId = 3,
            //                PharmacyId = 3
            //            }

            //        });
            //        context.SaveChanges();
            //    }
            //    // DeliveryPerson_Pharmacy
            //    if (!context.DeliveryPersonsPharmacies.Any())
            //    {
            //        context.DeliveryPersonsPharmacies.AddRange(new List<DeliveryPerson_Pharmacy>()
            //        {
            //            new DeliveryPerson_Pharmacy()
            //            {
            //                DeliveryPersonId = 1,
            //                PharmacyId = 5
            //            },
            //             new DeliveryPerson_Pharmacy()
            //            {
            //                DeliveryPersonId = 3,
            //                PharmacyId = 4
            //            },
            //              new DeliveryPerson_Pharmacy()
            //            {
            //                DeliveryPersonId = 2,
            //                PharmacyId = 3
            //            }

            //        });
            //        context.SaveChanges();
            //    }


            //    //DigitalPrescription_Pharmacy
            //    if (!context.DigitalPrescriptionsPharmacies.Any())
            //    {
            //        context.DigitalPrescriptionsPharmacies.AddRange(new List<DigitalPrescription_Pharmacy>()
            //        {
            //            new DigitalPrescription_Pharmacy()
            //            {
            //                DigitalPrescriptionId = 2,
            //                PharmacyId = 4
            //            },
            //             new DigitalPrescription_Pharmacy()
            //            {
            //                DigitalPrescriptionId = 3,
            //                PharmacyId = 3
            //            },
            //              new DigitalPrescription_Pharmacy()
            //            {
            //                DigitalPrescriptionId = 1,
            //                PharmacyId = 2
            //            }

            //        });
            //        context.SaveChanges();
            //    }



            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                //Admin
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                //User
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Doctor
                if (!await roleManager.RoleExistsAsync(UserRoles.Doctor))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Doctor));

                //Pharmacist
                if (!await roleManager.RoleExistsAsync(UserRoles.Pharmacist))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Pharmacist));

                //DeliveryPerson
                if (!await roleManager.RoleExistsAsync(UserRoles.DeliveryPerson))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.DeliveryPerson));


                //Users

                //Admin
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FirstName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                //User
                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FirstName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

                //Doctor
                string appDoctorUserEmail = "doctor@etickets.com";

                var appDoctorUser = await userManager.FindByEmailAsync(appDoctorUserEmail);
                if (appDoctorUser == null)
                {
                    var newAppDoctorUser = new ApplicationUser()
                    {
                        FirstName = "Doctor",
                        UserName = "app-user-doctor",
                        Email = appDoctorUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppDoctorUser, "DoctorCoding@1234?");
                    await userManager.AddToRoleAsync(newAppDoctorUser, UserRoles.Doctor);
                }

                //Pharmacist
                string appPharmacistUserEmail = "pharmacy@etickets.com";

                var appPharmacistUser = await userManager.FindByEmailAsync(appPharmacistUserEmail);
                if (appPharmacistUser == null)
                {
                    var newAppPharmacistUser = new ApplicationUser()
                    {
                        FirstName = "Application User",
                        UserName = "app-user-pharmacist",
                        Email = appPharmacistUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppPharmacistUser, "PharmacistCoding@1234?");
                    await userManager.AddToRoleAsync(newAppPharmacistUser, UserRoles.Pharmacist);
                }

                //DeliveryPerson
                string appDeliveryPersonUserEmail = "dperson@etickets.com";

                var appDeliveryPersonUser = await userManager.FindByEmailAsync(appDeliveryPersonUserEmail);
                if (appDeliveryPersonUser == null)
                {
                    var newAppDeliveryPersonUser = new ApplicationUser()
                    {
                        FirstName = "Application User",
                        UserName = "app-user-dperson",
                        Email = appDeliveryPersonUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppDeliveryPersonUser, "DPersonCoding@1234?");
                    await userManager.AddToRoleAsync(newAppDeliveryPersonUser, UserRoles.DeliveryPerson);
                }


            }
        }

    }
}
