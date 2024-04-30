import KorisniciDodaj from "../pages/korisnici/KorisniciDodaj";
import {HttpService} from "./HttpService"

const naziv = '/Korisnik'

async function get(){
    return await HttpService.get(naziv)
    .then((odgovor)=>{
        //console.table(odgovor.data);
        return odgovor.data;
    })
    .catch((e)=>{
        //console.log(e);
        return e;
    })
}

async function post(korisnik){
    return await HttpService.post(naziv, korisnik)
    .then((odgovor)=>{
        //console.table(odgovor.data);
        return {greska: false, poruka: odgovor.data};
    })
    .catch((e)=>{
        //console.log(e);
        return {greska: true, poruka: e};
    })
}

async function put(sifra, korisnik){
    return await HttpService.put(ime + '/' + sifra, korisnik)
    .then((odgovor)=>{
        //console.table(odgovor.data);
        return {greska: false, poruka: odgovor.data};
    })
    .catch((e)=>{
        //console.log(e);
        return {greska: true, poruka: e};
    })
}


async function _delete(sifraKorisnika){
    return await HttpService.delete(naziv + '/' + sifraKorisnika)
    .then((odgovor)=>{
        //console.table(odgovor.data);
        return {greska: false, poruka: odgovor.data.poruka};
    })
    .catch((e)=>{
        //console.log(e);
        return {greska: true, poruka: e};
    })
    
}

async function getBySifra(sifra){
    return await HttpService.get(naziv + '/' + sifra)
    .then((odgovor)=>{
        //console.table(odgovor.data);
        return {greska: false, poruka: odgovor.data};
    })
    .catch((e)=>{
        //console.log(e);
        return {greska: true, poruka: e};
    })
}
export default{
    get,
    post,
    _delete,
    put,
    getBySifra
    
}