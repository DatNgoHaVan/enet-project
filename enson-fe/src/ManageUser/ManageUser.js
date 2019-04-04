import React, { Component } from 'react';

import './ManageUserCss.css';
import total from '../assets/images/total.png';
import up from '../assets/images/up.png';
import newUser from '../assets/images/newUser.png';
import onlineUser from '../assets/images/onlineUser.png';
import banUser from '../assets/images/banUser.png'
import PageNavigationTable from '../components/PageNavigationTable';

class ManageUser extends Component {

    constructor(props) {
        super(props);
        this.state = {
            page: 1,
            data: [],
            renderData: [],
        }
        this.onPageChanged = this.onPageChanged.bind(this);
    }

    componentDidMount() {
        const data = [
            {
                "id": 1,
                "name": "Allistir",
                "username": "abentick0",
                "email": "aschiell0@google.ru",
                "role": "Mr"
            }, {
                "id": 2,
                "name": "Corene",
                "username": "chighway1",
                "email": "cpurveys1@blogtalkradio.com",
                "role": "Ms"
            }, {
                "id": 3,
                "name": "Rawley",
                "username": "rpotteridge2",
                "email": "rhulme2@eepurl.com",
                "role": "Mrs"
            }, {
                "id": 4,
                "name": "Bryn",
                "username": "beddington3",
                "email": "bprozescky3@dmoz.org",
                "role": "Ms"
            }, {
                "id": 5,
                "name": "Che",
                "username": "ckeavy4",
                "email": "cgolling4@illinois.edu",
                "role": "Honorable"
            }, {
                "id": 6,
                "name": "Odelle",
                "username": "obellamy5",
                "email": "ofitzroy5@wordpress.org",
                "role": "Rev"
            }, {
                "id": 7,
                "name": "Stefania",
                "username": "scashen6",
                "email": "shaysey6@discovery.com",
                "role": "Honorable"
            }, {
                "id": 8,
                "name": "Kali",
                "username": "kcleveland7",
                "email": "khails7@xinhuanet.com",
                "role": "Mr"
            }, {
                "id": 9,
                "name": "Shanna",
                "username": "sbuddleigh8",
                "email": "slindholm8@bizjournals.com",
                "role": "Rev"
            }, {
                "id": 10,
                "name": "Francesca",
                "username": "fdeedes9",
                "email": "fclaricoates9@cbslocal.com",
                "role": "Mrs"
            }, {
                "id": 11,
                "name": "Crysta",
                "username": "crushmana",
                "email": "ctinwella@upenn.edu",
                "role": "Ms"
            }, {
                "id": 12,
                "name": "Nita",
                "username": "ntresiseb",
                "email": "nmcalisterb@elegantthemes.com",
                "role": "Mr"
            }, {
                "id": 13,
                "name": "Alyson",
                "username": "aclaibournc",
                "email": "amacsorleyc@apache.org",
                "role": "Ms"
            }, {
                "id": 14,
                "name": "Nannie",
                "username": "ngarrowd",
                "email": "nvickermand@sogou.com",
                "role": "Mr"
            }, {
                "id": 15,
                "name": "Diandra",
                "username": "ddysone",
                "email": "dhawthornee@xrea.com",
                "role": "Dr"
            }, {
                "id": 16,
                "name": "Matias",
                "username": "mmcilwrickf",
                "email": "mshierf@comcast.net",
                "role": "Dr"
            }, {
                "id": 17,
                "name": "Charmine",
                "username": "chambyg",
                "email": "clambshineg@seattletimes.com",
                "role": "Mr"
            }, {
                "id": 18,
                "name": "Maryann",
                "username": "mpetruskah",
                "email": "medwardsonh@bloglines.com",
                "role": "Honorable"
            }, {
                "id": 19,
                "name": "Dacey",
                "username": "dheddoni",
                "email": "dmordeyi@accuweather.com",
                "role": "Mr"
            }, {
                "id": 20,
                "name": "Andromache",
                "username": "atreslovej",
                "email": "astienhamj@desdev.cn",
                "role": "Mrs"
            }, {
                "id": 21,
                "name": "Boyd",
                "username": "bbroxapk",
                "email": "bpomfrettk@bluehost.com",
                "role": "Ms"
            }, {
                "id": 22,
                "name": "Sean",
                "username": "sfalcol",
                "email": "sartingstalll@craigslist.org",
                "role": "Dr"
            }, {
                "id": 23,
                "name": "Latashia",
                "username": "lmaddickm",
                "email": "lheppenspallm@nps.gov",
                "role": "Dr"
            }, {
                "id": 24,
                "name": "Dian",
                "username": "dromainn",
                "email": "dleandern@joomla.org",
                "role": "Ms"
            }, {
                "id": 25,
                "name": "Hyacinth",
                "username": "hdemarso",
                "email": "hdenleyo@w3.org",
                "role": "Ms"
            }, {
                "id": 26,
                "name": "Renee",
                "username": "rkeldp",
                "email": "rtrimmellp@guardian.co.uk",
                "role": "Mr"
            }, {
                "id": 27,
                "name": "Jonell",
                "username": "jgaviganq",
                "email": "jcawtheraq@epa.gov",
                "role": "Mr"
            }, {
                "id": 28,
                "name": "Kass",
                "username": "kgilloppr",
                "email": "kdrawmerr@tinypic.com",
                "role": "Mrs"
            }, {
                "id": 29,
                "name": "Cosimo",
                "username": "cmanicombs",
                "email": "cupjohns@google.com",
                "role": "Ms"
            }, {
                "id": 30,
                "name": "Marci",
                "username": "mphetteplacet",
                "email": "mbreetont@blogspot.com",
                "role": "Mr"
            }, {
                "id": 31,
                "name": "Fredericka",
                "username": "fpingstoneu",
                "email": "fmatussonu@deliciousdays.com",
                "role": "Mrs"
            }, {
                "id": 32,
                "name": "Tamma",
                "username": "tfourmyv",
                "email": "ttamlettv@dedecms.com",
                "role": "Honorable"
            }, {
                "id": 33,
                "name": "Krissy",
                "username": "kdrinkwaterw",
                "email": "kextallw@etsy.com",
                "role": "Rev"
            }, {
                "id": 34,
                "name": "Ansell",
                "username": "afilippovx",
                "email": "awyldborex@youtu.be",
                "role": "Mr"
            }, {
                "id": 35,
                "name": "Alison",
                "username": "aemmety",
                "email": "aedmundy@china.com.cn",
                "role": "Mr"
            }, {
                "id": 36,
                "name": "Jamey",
                "username": "jhallowayz",
                "email": "javeyz@wikipedia.org",
                "role": "Mrs"
            }, {
                "id": 37,
                "name": "Gamaliel",
                "username": "graoux10",
                "email": "gkowal10@netscape.com",
                "role": "Mrs"
            }, {
                "id": 38,
                "name": "Gabie",
                "username": "gtuminelli11",
                "email": "glofts11@wikimedia.org",
                "role": "Rev"
            }, {
                "id": 39,
                "name": "Douglas",
                "username": "dmee12",
                "email": "dwhitehall12@github.com",
                "role": "Mrs"
            }, {
                "id": 40,
                "name": "Keith",
                "username": "kdaniel13",
                "email": "kerrichi13@deviantart.com",
                "role": "Dr"
            }, {
                "id": 41,
                "name": "Arline",
                "username": "aduns14",
                "email": "apasley14@fda.gov",
                "role": "Dr"
            }, {
                "id": 42,
                "name": "Berta",
                "username": "bmyring15",
                "email": "blawrance15@ezinearticles.com",
                "role": "Honorable"
            }, {
                "id": 43,
                "name": "Erma",
                "username": "eholby16",
                "email": "ereskelly16@vk.com",
                "role": "Rev"
            }, {
                "id": 44,
                "name": "Eveline",
                "username": "eaverall17",
                "email": "egovinlock17@printfriendly.com",
                "role": "Rev"
            }, {
                "id": 45,
                "name": "Ilse",
                "username": "icardoo18",
                "email": "ichaimson18@scribd.com",
                "role": "Mr"
            }, {
                "id": 46,
                "name": "Rutter",
                "username": "rgrut19",
                "email": "rludl19@java.com",
                "role": "Ms"
            }, {
                "id": 47,
                "name": "Jarrad",
                "username": "jbermingham1a",
                "email": "jholmyard1a@purevolume.com",
                "role": "Ms"
            }, {
                "id": 48,
                "name": "Haley",
                "username": "htarbox1b",
                "email": "hswayte1b@prlog.org",
                "role": "Rev"
            }, {
                "id": 49,
                "name": "Kacey",
                "username": "kfernyhough1c",
                "email": "kcicchillo1c@nationalgeographic.com",
                "role": "Rev"
            }, {
                "id": 50,
                "name": "Mylo",
                "username": "mdavys1d",
                "email": "mcayette1d@meetup.com",
                "role": "Mr"
            }, {
                "id": 51,
                "name": "Anselm",
                "username": "agecke1e",
                "email": "ajansens1e@aboutads.info",
                "role": "Ms"
            }, {
                "id": 52,
                "name": "Giff",
                "username": "gkilfedder1f",
                "email": "gconring1f@europa.eu",
                "role": "Mrs"
            }, {
                "id": 53,
                "name": "Eudora",
                "username": "elindblad1g",
                "email": "ekeen1g@wordpress.com",
                "role": "Mr"
            }, {
                "id": 54,
                "name": "Sylas",
                "username": "scannan1h",
                "email": "sreyna1h@nbcnews.com",
                "role": "Mr"
            }, {
                "id": 55,
                "name": "Sig",
                "username": "sleach1i",
                "email": "smiell1i@quantcast.com",
                "role": "Dr"
            }, {
                "id": 56,
                "name": "Shelton",
                "username": "sgehring1j",
                "email": "sgarfit1j@technorati.com",
                "role": "Honorable"
            }, {
                "id": 57,
                "name": "Gunilla",
                "username": "gwoollends1k",
                "email": "ggrumley1k@yellowpages.com",
                "role": "Mr"
            }, {
                "id": 58,
                "name": "Garnette",
                "username": "growett1l",
                "email": "ghaste1l@rediff.com",
                "role": "Rev"
            }, {
                "id": 59,
                "name": "Melly",
                "username": "mgutcher1m",
                "email": "mcrohan1m@taobao.com",
                "role": "Rev"
            }, {
                "id": 60,
                "name": "Marga",
                "username": "mbrastead1n",
                "email": "mhackleton1n@w3.org",
                "role": "Ms"
            }, {
                "id": 61,
                "name": "Evangeline",
                "username": "etilt1o",
                "email": "ematussevich1o@cmu.edu",
                "role": "Dr"
            }, {
                "id": 62,
                "name": "Correy",
                "username": "cschanke1p",
                "email": "cmcgloin1p@gravatar.com",
                "role": "Mrs"
            }, {
                "id": 63,
                "name": "Merrilee",
                "username": "mridgeway1q",
                "email": "mdufaire1q@ifeng.com",
                "role": "Honorable"
            }, {
                "id": 64,
                "name": "Kerri",
                "username": "kbysh1r",
                "email": "kzealey1r@cbslocal.com",
                "role": "Rev"
            }, {
                "id": 65,
                "name": "Archibald",
                "username": "agounod1s",
                "email": "aellins1s@cbc.ca",
                "role": "Mr"
            }, {
                "id": 66,
                "name": "El",
                "username": "eliggons1t",
                "email": "edeeman1t@imgur.com",
                "role": "Rev"
            }, {
                "id": 67,
                "name": "Ray",
                "username": "rwinscom1u",
                "email": "rsuttell1u@wisc.edu",
                "role": "Dr"
            }, {
                "id": 68,
                "name": "Terrell",
                "username": "tparradice1v",
                "email": "tpoveleye1v@xrea.com",
                "role": "Dr"
            }, {
                "id": 69,
                "name": "Christian",
                "username": "cdaggett1w",
                "email": "chuck1w@fotki.com",
                "role": "Ms"
            }, {
                "id": 70,
                "name": "Madelina",
                "username": "mdanielou1x",
                "email": "mnealand1x@zdnet.com",
                "role": "Ms"
            }, {
                "id": 71,
                "name": "Corenda",
                "username": "cmatches1y",
                "email": "cportail1y@cargocollective.com",
                "role": "Mrs"
            }, {
                "id": 72,
                "name": "Dorothea",
                "username": "dcleynman1z",
                "email": "dbridden1z@fastcompany.com",
                "role": "Dr"
            }, {
                "id": 73,
                "name": "Anatollo",
                "username": "abarnewelle20",
                "email": "awild20@1und1.de",
                "role": "Ms"
            }, {
                "id": 74,
                "name": "Sheffie",
                "username": "scrosfield21",
                "email": "sshillum21@newyorker.com",
                "role": "Dr"
            }, {
                "id": 75,
                "name": "Conn",
                "username": "cgadd22",
                "email": "cjansema22@mac.com",
                "role": "Ms"
            }, {
                "id": 76,
                "name": "Matias",
                "username": "mhathway23",
                "email": "mjobes23@hud.gov",
                "role": "Dr"
            }, {
                "id": 77,
                "name": "Randell",
                "username": "rmacbain24",
                "email": "rgrestie24@ning.com",
                "role": "Honorable"
            }, {
                "id": 78,
                "name": "Allister",
                "username": "afoulger25",
                "email": "ahabercham25@time.com",
                "role": "Dr"
            }, {
                "id": 79,
                "name": "Brear",
                "username": "bstowte26",
                "email": "bpaybody26@yellowpages.com",
                "role": "Dr"
            }, {
                "id": 80,
                "name": "Sosanna",
                "username": "sdelve27",
                "email": "seaston27@github.io",
                "role": "Rev"
            }, {
                "id": 81,
                "name": "Frans",
                "username": "fgreig28",
                "email": "fmusprat28@businessinsider.com",
                "role": "Rev"
            }, {
                "id": 82,
                "name": "Jessamyn",
                "username": "jboud29",
                "email": "jblasiak29@reverbnation.com",
                "role": "Mrs"
            }, {
                "id": 83,
                "name": "Benedict",
                "username": "bfeatonby2a",
                "email": "bmeegin2a@surveymonkey.com",
                "role": "Honorable"
            }, {
                "id": 84,
                "name": "Nahum",
                "username": "nrosenberg2b",
                "email": "nbalwin2b@yale.edu",
                "role": "Rev"
            }, {
                "id": 85,
                "name": "Horatio",
                "username": "hmacconnell2c",
                "email": "hjuszczyk2c@zimbio.com",
                "role": "Ms"
            }, {
                "id": 86,
                "name": "Mareah",
                "username": "mdarragh2d",
                "email": "motham2d@wikipedia.org",
                "role": "Dr"
            }, {
                "id": 87,
                "name": "Dore",
                "username": "dtudge2e",
                "email": "dcallam2e@omniture.com",
                "role": "Dr"
            }, {
                "id": 88,
                "name": "Lannie",
                "username": "lchatin2f",
                "email": "lbread2f@studiopress.com",
                "role": "Dr"
            }, {
                "id": 89,
                "name": "Denver",
                "username": "dtilbrook2g",
                "email": "dhallatt2g@amazon.co.jp",
                "role": "Dr"
            }, {
                "id": 90,
                "name": "Aubrey",
                "username": "afleischer2h",
                "email": "asandford2h@bing.com",
                "role": "Ms"
            }, {
                "id": 91,
                "name": "Lucine",
                "username": "lwoodage2i",
                "email": "lmarryatt2i@reddit.com",
                "role": "Mrs"
            }, {
                "id": 92,
                "name": "Any",
                "username": "aaleshkov2j",
                "email": "aricht2j@youtube.com",
                "role": "Mrs"
            }, {
                "id": 93,
                "name": "Mel",
                "username": "macey2k",
                "email": "mbaterip2k@apache.org",
                "role": "Ms"
            }, {
                "id": 94,
                "name": "Burlie",
                "username": "bgrinley2l",
                "email": "bvaud2l@japanpost.jp",
                "role": "Mr"
            }, {
                "id": 95,
                "name": "Danielle",
                "username": "dgalilee2m",
                "email": "dpecha2m@ameblo.jp",
                "role": "Mr"
            }, {
                "id": 96,
                "name": "Bonnee",
                "username": "brilton2n",
                "email": "bbullers2n@uol.com.br",
                "role": "Dr"
            }, {
                "id": 97,
                "name": "Bradford",
                "username": "bcoulthard2o",
                "email": "bpretty2o@amazon.com",
                "role": "Dr"
            }, {
                "id": 98,
                "name": "Olenka",
                "username": "ozaniolini2p",
                "email": "obrice2p@usatoday.com",
                "role": "Rev"
            }, {
                "id": 99,
                "name": "Ruthanne",
                "username": "rbagguley2q",
                "email": "rventris2q@amazonaws.com",
                "role": "Mr"
            }, {
                "id": 100,
                "name": "Suzette",
                "username": "scasford2r",
                "email": "sjemison2r@scribd.com",
                "role": "Honorable"
            }];
        this.setState({ data: data });
    }

    onPageChanged(value) {
        const dataPage = value * 10 - 10;
        const arr = this.state.data;
        this.state({ renderData: arr.splice(dataPage, 10) })
    }

    render() {
        const {data} = this.state;
        console.log(data.length);
        return (
            <div class="container" style={{ width: '100%', maxWidth: '1270px', marginTop: '45px' }}>
                <div class="row">
                    <div class="col-lg-3">
                        <div className="tagContainer">
                            <div className="form-inline">
                                <div className="titleContainer">
                                    <div className="tagTitle "><p>Total user</p></div>
                                    <div className="tagNumber"><p>120,154,021</p></div>
                                </div>
                                <div className="imageContainer">
                                    <img className="tagImage" src={total}></img>
                                </div>
                            </div>
                            <div>
                                <div className="form-inline" style={{ marginLeft: '15px', height: '60px' }}>
                                    <img className="imageUP" className="imageUD" src={up} />
                                    <p style={{ fontSize: '14px', paddingTop: '11px', marginBottom: '0px' }}>5.48% since last week</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div className="tagContainer">
                            <div className="form-inline">
                                <div className="titleContainer">
                                    <div className="tagTitle "><p>New user</p></div>
                                    <div className="tagNumber"><p>120,154,021</p></div>
                                </div>
                                <div className="imageContainer">
                                    <img className="tagImage" src={newUser}></img>
                                </div>
                            </div>
                            <div>
                                <div className="form-inline" style={{ marginLeft: '15px', height: '60px' }}>
                                    <img className="imageUP" className="imageUD" src={up} />
                                    <p style={{ fontSize: '14px', paddingTop: '11px', marginBottom: '0px' }}>5.48% since last week</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div className="tagContainer">
                            <div className="form-inline">
                                <div className="titleContainer">
                                    <div className="tagTitle "><p>Online user</p></div>
                                    <div className="tagNumber"><p>120,154,021</p></div>
                                </div>
                                <div className="imageContainer">
                                    <img className="tagImage" src={onlineUser}></img>
                                </div>
                            </div>
                            <div>
                                <div className="form-inline" style={{ marginLeft: '15px', height: '60px' }}>
                                    <img className="imageUP" className="imageUD" src={up} />
                                    <p style={{ fontSize: '14px', paddingTop: '11px', marginBottom: '0px' }}>5.48% since last week</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <div className="tagContainer">
                            <div className="form-inline">
                                <div className="titleContainer">
                                    <div className="tagTitle "><p>Ban user</p></div>
                                    <div className="tagNumber"><p>120,154,021</p></div>
                                </div>
                                <div className="imageContainer">
                                    <img className="tagImage" src={banUser}></img>
                                </div>
                            </div>
                            <div>
                                <div className="form-inline" style={{ marginLeft: '15px', height: '60px' }}>
                                    <img className="imageUP" className="imageUD" src={up} />
                                    <p style={{ fontSize: '14px', paddingTop: '11px', marginBottom: '0px' }}>5.48% since last week</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style={{ marginTop: '40px' }}>
                    <table style={{ width: '100%' }}>
                        <tr>
                            <td className="tableNameContainer"><p className="tableName">User table</p></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td><button type="button" className="btn btn-success">New user</button></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
        <td>{data.length ===0 ? '':<PageNavigationTable totalRecords={data.length} onPageChanged={this.onPageChanged} />}</td>
                        </tr>
                    </table>
                </div>
            </div>
        );
    }
}

export default ManageUser;