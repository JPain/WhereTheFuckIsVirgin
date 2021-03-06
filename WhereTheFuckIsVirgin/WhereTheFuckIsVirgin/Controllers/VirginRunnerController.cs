﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using WhereTheFuckIsVirgin.Models;
using Newtonsoft.Json;

namespace WhereTheFuckIsVirgin.Controllers
{
    public class VirginRunnerController : ApiController
    {

        string _virginUrl = "https://cablemystreet.virginmedia.com/cms/api/getCMSResponse?postcode=";
        

        // GET api/virginrunner/1
        public IEnumerable<Address> Get(int townId)
        {
            var _towns = new List<Town>()
            {
                new Town {Id = 1, Name = "Colchester", Postcodes = new List<string> { "CO11AG","CO11AH","CO11AJ","CO11AN","CO11AP","CO11AU","CO11AW","CO11BA","CO11BB","CO11BE","CO11BG","CO11BN","CO11BP","CO11BQ","CO11BU","CO11BX","CO11BY","CO11BZ","CO11DA","CO11DB","CO11DF","CO11DG","CO11DH","CO11DJ","CO11DL","CO11DN","CO11DQ","CO11DS","CO11DU","CO11DW","CO11DX","CO11DZ","CO11EA","CO11EB","CO11ED","CO11EE","CO11EG","CO11EH","CO11EJ","CO11EL","CO11EN","CO11EQ","CO11ES","CO11EU","CO11EW","CO11EY","CO11EZ","CO11FF","CO11FL","CO11FN","CO11FP","CO11FR","CO11GG","CO11GJ","CO11GP","CO11GQ","CO11GR","CO11GX","CO11HA","CO11HB","CO11HD","CO11HE","CO11HF","CO11HG","CO11HJ","CO11HL","CO11HN","CO11HP","CO11HQ","CO11HR","CO11HS","CO11HT","CO11HW","CO11HY","CO11HZ","CO11JB","CO11JG","CO11JJ","CO11JN","CO11JQ","CO11JR","CO11JT","CO11JW","CO11JZ","CO11LA","CO11LB","CO11LD","CO11LE","CO11LF","CO11LG","CO11LH","CO11LJ","CO11LL","CO11LN","CO11LP","CO11LR","CO11LS","CO11LX","CO11LZ","CO11NE","CO11NF","CO11NG","CO11NH","CO11NN","CO11NP","CO11NS","CO11NT","CO11NU","CO11NW","CO11NX","CO11NY","CO11NZ","CO11PA","CO11PB","CO11PD","CO11PG","CO11PJ","CO11PN","CO11PR","CO11PT","CO11PW","CO11PX","CO11PY","CO11QA","CO11QD","CO11QE","CO11QF","CO11QG","CO11QH","CO11QP","CO11QR","CO11QS","CO11QT","CO11QX","CO11QY","CO11RB","CO11RD","CO11RE","CO11RF","CO11RH","CO11RJ","CO11RL","CO11RP","CO11RQ","CO11RR","CO11RS","CO11RT","CO11RU","CO11RX","CO11RY","CO11RZ","CO11SA","CO11SB","CO11SE","CO11SF","CO11SG","CO11SH","CO11SJ","CO11SN","CO11SP","CO11SQ","CO11SR","CO11SS","CO11ST","CO11SY","CO11SZ","CO11TB","CO11TD","CO11TG","CO11TH","CO11TJ","CO11TL","CO11TN","CO11TP","CO11TS","CO11TT","CO11TW","CO11TX","CO11TY","CO11TZ","CO11UA","CO11UB","CO11UD","CO11UE","CO11UF","CO11UG","CO11UL","CO11UN","CO11UP","CO11UR","CO11US","CO11UT","CO11UU","CO11UW","CO11UX","CO11UY","CO11UZ","CO11WA","CO11WB","CO11WD","CO11WE","CO11WF","CO11WG","CO11WJ","CO11WN","CO11WQ","CO11WR","CO11WW","CO11XA","CO11XD","CO11XF","CO11XJ","CO11XL","CO11XN","CO11XP","CO11XR","CO11XS","CO11XT","CO11XW","CO11XX","CO11XY","CO11XZ","CO11YA","CO11YD","CO11YE","CO11YF","CO11YG","CO11YH","CO11YJ","CO11YN","CO11YP","CO11YZ","CO11ZA","CO11ZE","CO11ZH","CO11ZP","CO11ZR","CO11ZS","CO11ZT","CO11ZU","CO11ZX","CO11ZY","CO12AA","CO12AD","CO12AF","CO12AG","CO12AH","CO12AJ","CO12AN","CO12AP","CO12AQ","CO12AR","CO12AS","CO12AT","CO12AU","CO12AW","CO12AX","CO12AY","CO12AZ","CO12BB","CO12BD","CO12BE","CO12BG","CO12BH","CO12BJ","CO12BL","CO12BN","CO12BP","CO12BQ","CO12BS","CO12BU","CO12BX","CO12BY","CO12BZ","CO12DB","CO12DD","CO12DE","CO12DG","CO12DH","CO12DL","CO12DN","CO12DP","CO12DR","CO12DS","CO12DT","CO12DU","CO12DW","CO12DZ","CO12EA","CO12EB","CO12ED","CO12EE","CO12EF","CO12EG","CO12EL","CO12EN","CO12EP","CO12ER","CO12ES","CO12ET","CO12EU","CO12EW","CO12EX","CO12EY","CO12EZ","CO12FE","CO12FF","CO12FG","CO12FH","CO12FJ","CO12FL","CO12FP","CO12FT","CO12FX","CO12GB","CO12GD","CO12GE","CO12GJ","CO12GL","CO12GN","CO12GP","CO12GQ","CO12GS","CO12GU","CO12GW","CO12GX","CO12GY","CO12GZ","CO12HA","CO12HB","CO12HD","CO12HE","CO12HF","CO12HG","CO12HH","CO12HJ","CO12HL","CO12HN","CO12HP","CO12HR","CO12HS","CO12HT","CO12HU","CO12HW","CO12HX","CO12HY","CO12HZ","CO12JA","CO12JB","CO12JD","CO12JE","CO12JF","CO12JG","CO12JH","CO12JJ","CO12JL","CO12JP","CO12JQ","CO12JR","CO12JS","CO12JT","CO12JU","CO12JW","CO12JX","CO12JZ","CO12LA","CO12LB","CO12LD","CO12LE","CO12LF","CO12LH","CO12LJ","CO12LL","CO12LN","CO12LP","CO12LQ","CO12LR","CO12LS","CO12LT","CO12LU","CO12LW","CO12LX","CO12LY","CO12LZ","CO12NA","CO12NB","CO12NE","CO12NF","CO12NG","CO12NH","CO12NJ","CO12NL","CO12NN","CO12NP","CO12NQ","CO12NR","CO12NS","CO12NT","CO12NU","CO12NW","CO12NX","CO12NZ","CO12PA","CO12PF","CO12PG","CO12PH","CO12PJ","CO12PL","CO12PQ","CO12PR","CO12PS","CO12PU","CO12PW","CO12PX","CO12PY","CO12PZ","CO12QA","CO12QB","CO12QD","CO12QE","CO12QG","CO12QL","CO12QN","CO12QR","CO12QS","CO12QT","CO12QU","CO12QW","CO12QX","CO12QY","CO12QZ","CO12RA","CO12RB","CO12RD","CO12RE","CO12RF","CO12RG","CO12RH","CO12RJ","CO12RL","CO12RN","CO12RP","CO12RQ","CO12RR","CO12RS","CO12RT","CO12RU","CO12RW","CO12RX","CO12RZ","CO12SA","CO12SB","CO12SD","CO12SE","CO12SF","CO12SG","CO12SH","CO12SJ","CO12SL","CO12SN","CO12SP","CO12SQ","CO12ST","CO12SU","CO12SW","CO12SX","CO12SY","CO12SZ","CO12TA","CO12TB","CO12TE","CO12TG","CO12TH","CO12TJ","CO12TL","CO12TN","CO12TP","CO12TQ","CO12TR","CO12TS","CO12TT","CO12TU","CO12TX","CO12TZ","CO12UD","CO12UF","CO12UG","CO12UJ","CO12UL","CO12UP","CO12UQ","CO12UR","CO12US","CO12UT","CO12UU","CO12UW","CO12UY","CO12UZ","CO12WA","CO12WB","CO12WF","CO12WG","CO12WJ","CO12WS","CO12WT","CO12XA","CO12XD","CO12XE","CO12XF","CO12XH","CO12XJ","CO12XL","CO12XS","CO12XT","CO12XU","CO12YB","CO12YD","CO12YE","CO12YG","CO12YH","CO12YL","CO12YN","CO12YR","CO12YT","CO12YU","CO12YW","CO12ZD","CO12ZE","CO12ZF","CO12ZG","CO19AL","CO19AQ","CO19AX","CO19BB","CO19BG","CO19BJ","CO19BW","CO19DH","CO19DL","CO19DS","CO19DU","CO19ED","CO19EL","CO19EP","CO19EU","CO19EZ","CO19FA","CO19FD","CO19FE","CO19FH","CO19FN","CO19FQ","CO19FR","CO19FT","CO19FU","CO19GD","CO19GJ","CO19GL","CO19GP","CO19GQ","CO19GR","CO19GW","CO19GX","CO19GY","CO19GZ","CO19HG","CO19HH","CO19HJ","CO19HL","CO19HP","CO19HQ","CO19HU","CO19HX","CO19HZ","CO19JA","CO19JB","CO19JD","CO19JE","CO19JF","CO19JG","CO19JH","CO19JJ","CO19JL","CO19JN","CO19JP","CO19JQ","CO19JR","CO19JS","CO19JT","CO19JW","CO19JX","CO19JY","CO19JZ","CO19LA","CO19LB","CO19LD","CO19LE","CO19LG","CO19LH","CO19SA","CO19SB","CO19SD","CO19SE","CO19SF","CO19SG","CO19SH","CO19SJ","CO19SL","CO19SP","CO19SQ","CO19SR","CO19SS","CO19ST","CO19SU","CO19SW","CO19SX","CO19SY","CO19SZ","CO19TA","CO19TB","CO19TD","CO19TE","CO19TF","CO19TG","CO19TH","CO19TJ","CO19TL","CO19TN"}}
            };

            //var _towns = new List<Town>()
            //{
            //    new Town {Id = 1, Name = "Colchester", Postcodes = new List<string> { "CO1 1AG","CO1 1AH","CO1 9TN"}}
            //};


            var town = _towns.FirstOrDefault((t) => t.Id == townId);
            var addresses = new List<Address>();

            foreach (var postcode in town.Postcodes)
            {
                var request = WebRequest.Create(_virginUrl + postcode);
                var response = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                var returnedCms = JsonConvert.DeserializeObject<VrGetCmsResponse>(response);
                if (returnedCms.ResponseStatus == "Exception")
                {
                    continue;
                }

                addresses.AddRange(returnedCms.Address.Where(address => !string.IsNullOrEmpty(address.uid)));
            }

            return addresses;
        }

        private string GetPostcode(string postcode)
        {


            return "";
        }
    }
}
