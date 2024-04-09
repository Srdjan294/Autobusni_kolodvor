import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import KorisnikService from "../../services/KorisnikService";


export default function KorisniciDodaj(){

    const navigate = useNavigate();

    async function dodaj(korisnik){
        const odgovor = await KorisnikService.post(korisnik);
        if(odgovor.greska){
            console.log(odgovor.poruka);
            alert('Pogledaj konzolu');
            return;
        }
        navigate(RoutesNames.KORISNIK_PREGLED);
    }

    function obradiSubmit(e){ // e predstavlja event
        e.preventDefault();
        //alert('Dodajem smjer');

        const podaci = new FormData(e.target);

        const korisnik = {

            ime: podaci.get('ime'),
            prezime: podaci.get('prezime'),
            brojMobitela: podaci.get('brojMobitela'),
            email: podaci.get('email'),  // naziv je name atribut u Form.Control
            
        };

        //console.log(smjer);

        dodaj(korisnik);
    }

    return (

        <Container>
            <Form onSubmit={obradiSubmit}>
                
                <Form.Group controlId = "ime">
                    <Form.Label>Ime</Form.Label>
                    <Form.Control type="text" name="ime" required />
                </Form.Group>

                <Form.Group controlId = "prezime">
                    <Form.Label>Prezime</Form.Label>
                    <Form.Control type="text" name="prezime" required />
                </Form.Group>

                <Form.Group controlId = "brojMobitela">
                    <Form.Label>Broj mobitela</Form.Label>
                    <Form.Control type="text" name="brojMobitela" required />
                </Form.Group>

                <Form.Group controlId = "email">
                    <Form.Label>Email</Form.Label>
                    <Form.Control type="text" name="email" required />
                </Form.Group>

                

                <hr />


                <Row>
                    <Col>
                        <Link className="btn btn-danger siroko" to={RoutesNames.KORISNIK_PREGLED}>
                            Odustani
                        </Link>
                    </Col>
                    <Col>
                        <Button className="siroko" variant="primary" type="submit">
                            Dodaj
                        </Button>
                    </Col>
                </Row>

            </Form>
        </Container>

    );
}