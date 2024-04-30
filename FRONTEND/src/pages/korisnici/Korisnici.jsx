import { useEffect, useState } from 'react';
import Container from 'react-bootstrap/Container';
import KorisnikService from '../../services/KorisnikService';
import {Button, Table } from 'react-bootstrap';
import { Link, useNavigate } from 'react-router-dom';
import {RoutesNames} from '../../constants'



export default function Korisnici(){
    const [korisnici, setKorisnici] = useState();
    const navigate = useNavigate();

    async function dohvatiKorisnici(){
        await KorisnikService.get()
        .then((odg)=>{
            setKorisnici(odg);
        })
        .catch((e)=>{
            console.log(e);
        });
    }

    useEffect(()=>{
        dohvatiKorisnici();
    },[]);


    async function obrisiAsync(sifra){
        const odgovor = await KorisnikService._delete(sifra);
        if(odgovor.greska){
            console.log(odgovor.poruka);
            alert('Pogledaj konzolu');
            return;
        }
        dohvatiKorisnici();

    }

    function obrisi(sifra){
        obrisiAsync(sifra);
    }

    return(
        <>
           <Container>
            <Link to={RoutesNames.KORISNIK_NOVI}> Dodaj </Link>
            <Table striped bordered hover responsive>
                    <thead>
                        <tr>
                            <th>Ime</th>
                            <th>Prezime</th>
                            <th>Broj Mobitela</th>
                            <th>E-mail</th>
                            <th>Akcija</th>
                        </tr>
                    </thead>
                    <tbody>
                        {korisnici && korisnici.map((korisnik,index)=>(
                            <tr key={index}>
                                <td>{korisnici.ime}</td>
                                <td>{korisnici.prezime}</td>
                                <td>{korisnici.brojMobitela}</td>
                                <td>{korisnici.email}</td>
                                <td>
                                    <Button
                                    onClick={() => obrisi(korisnik.sifra)}
                                    variant = 'danger'
                                    >
                                    Obriši
                                    </Button>

                                    <Button
                                    onClick={() => {navigate(`/korisnici/${korisnik.sifra}`)}}
                                    >
                                    Promjeni
                                    </Button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
            </Table>
           </Container>
        </>
    );
}