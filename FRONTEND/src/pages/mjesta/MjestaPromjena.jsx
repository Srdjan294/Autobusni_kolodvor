import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RoutesNames } from "../../constants";
import MjestoService from "../../services/MjestoService";
import { useEffect, useState } from "react";


export default function MjestaPromjena(){
    const navigate = useNavigate();
    const routeParams = useParams();
    const [mjesto, setMjesto] = useState({});

   async function dohvatiMjesto(){
        const o = await MjestoService.getBySifra(routeParams.sifra);
        if(o.greska){
            console.log(o.poruka);
            alert('pogledaj konzolu');
            return;
        }
        setMjesto(o.poruka);
   }

   async function promjeni(mjesto){
    const odgovor = await MjestoService.put(routeParams.sifra,mjesto);
    if (odgovor.greska){
        console.log(odgovor.poruka);
        alert('Pogledaj konzolu');
        return;
    }
    navigate(RoutesNames.MJESTO_PREGLED);
}

   useEffect(()=>{
    console.log('Stigao');
    dohvatiMjesto();
   },[]);

    function obradiSubmit(e){ // e predstavlja event
        e.preventDefault();
        //alert('Dodajem smjer');

        const podaci = new FormData(e.target);

        const mjesto = {
            naziv: podaci.get('naziv'),  // 'naziv' je name atribut u Form.Control
                      
        };
        //console.log(routeParams.sifra);
        console.log(mjesto);
        promjeni(mjesto);

    }

    return (

        <Container>
            <Form onSubmit={obradiSubmit}>

                <Form.Group controlId="naziv">
                    <Form.Label>Naziv</Form.Label>
                    <Form.Control 
                    type="text" 
                    name="naziv" 
                    defaultValue={mjesto.naziv}
                    required />
                </Form.Group>

                

                <hr />
                <Row>
                    <Col>
                        <Link className="btn btn-danger siroko" to={RoutesNames.MJESTO_PREGLED}>
                            Odustani
                        </Link>
                    </Col>
                    <Col>
                        <Button className="siroko" variant="primary" type="submit">
                            Promjeni
                        </Button>
                    </Col>
                </Row>

            </Form>
        </Container>

    );
}