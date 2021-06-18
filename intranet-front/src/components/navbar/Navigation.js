import { Navbar, NavbarBrand, Nav } from 'react-bootstrap'
import './Navbar.css'

function Navigation() {
    return(
        <Navbar className="navbar" bg="dark" variant="dark">
            <NavbarBrand href="#home">RCZ Lubin</NavbarBrand>
            <Nav className="mr-auto">
                <Nav.Link href="home">Home</Nav.Link>
                <Nav.Link href="zarzadzenia">Aktualne zarządzenia</Nav.Link>
                <Nav.Link href="phonebook">Książka telefoniczna</Nav.Link>
                <Nav.Link href="bhp">BHP</Nav.Link>
                <Nav.Link href="links">Linki</Nav.Link>
            </Nav>
        </Navbar>
    ); 
}

export default Navigation;