import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import SmjerService from "../../services/MjestoService";


export default function MjestaDodaj(){

    const navigate = useNavigate();

    async function dodaj(mjesto){
        const odgovor = await MjestoService.post(mjesto);
        if(odgovor.greska){
            console.log(odgovor.poruka);
            alert('Pogledaj konzolu');
            return;
        }
        navigate(RoutesNames.MJESTO_PREGLED);
    }

    function obradiSubmit(e){ // e predstavlja event
        e.preventDefault();
        //alert('Dodajem smjer');

        const podaci = new FormData(e.target);

        const mjesto = {

            naziv: podaci.get('naziv'),  // naziv je name atribut u Form.Control
            
        };

        //console.log(smjer);

        dodaj(mjesto);
    }

    return (

        <Container>
            <Form onSubmit={obradiSubmit}>
                
                <Form.Group controlId = "naziv">
                    <Form.Label>Naziv</Form.Label>
                    <Form.Control type="text" name="naziv" required />
                </Form.Group>

                

                <hr />


                <Row>
                    <Col xs={6} sm={6} md={3} lg={6} xl={1} xxl={2}>
                        <Link className="btn btn-danger siroko" to={RoutesNames.MJESTO_PREGLED}>
                            Odustani
                        </Link>
                    </Col>
                    <Col xs={6} sm={6} md={9} lg={6} xl={1} xxl={10}>
                        <Button className="siroko" variant="primary" type="submit">
                            Dodaj
                        </Button>
                    </Col>
                </Row>

            </Form>
        </Container>

    );
}