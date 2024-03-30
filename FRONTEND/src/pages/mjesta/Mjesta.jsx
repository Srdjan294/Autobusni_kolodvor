import { useEffect, useState } from 'react';
import Container from 'react-bootstrap/Container';
import SmjerService from '../../services/MjestoService';
import {Button, Table } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import {RoutesNames} from '../../constants'



export default function Mjesta(){
    const [mjesta, setMjesta] = useState();


    async function dohvatiMjesta(){
        await MjestoService.get()
        .then((odg)=>{
            setMjesta(odg);
        })
        .catch((e)=>{
            console.log(e);
        });
    }

    useEffect(()=>{
        dohvatiMjesta();
    },[]);

    function formatirajVerificiran(v){
        if(v==null){
            return 'nije definirano';
        }

        if(v){
            return 'DA';
        }

        return 'NE';
    }

    async function obrisiAsync(sifra){
        const odgovor = await MjestoService._delete(sifra);
        if(odgovor.greska){
            console.log(odgovor.poruka);
            alert('Pogledaj konzolu');
            return;
        }
        dohvatiSmjerove();

    }

    function obrisi(sifra){
        obrisiAsync(sifra);
    }

    return(
        <>
           <Container>
            <Link to={RoutesNames.MJESTO_NOVI}> Dodaj </Link>
            <Table striped bordered hover responsive>
                    <thead>
                        <tr>
                            <th>Naziv</th>
                            <th>Akcija</th>
                        </tr>
                    </thead>
                    <tbody>
                        {mjesta && mjesta.map((mjesto,index)=>(
                            <tr key={index}>
                                <td>{mjesto.naziv}</td>
                            
                                <td>
                                    {formatirajVerificiran(mjesto.verificiran)}
                                    {/* 
                                    {smjer.verificiran==null 
                                    ? 'Nije definirano'
                                    : smjer.verificiran ? 'DA' : 'NE'}
                                    */}
                                </td>
                                <td>
                                    <Button
                                    onClick={() => obrisi(mjesto.sifra)}
                                    variant = 'danger'
                                    >
                                    Obriši
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