import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink, Nav,
 UncontrolledDropdown, DropdownToggle, DropdownItem, DropdownMenu} from 'reactstrap';
import { Link } from 'react-router-dom';
import './nav-menu.css';

export default class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor(props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render() {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
          <Container>
            <NavbarBrand tag={Link} to="/">Campus.WebUI</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <Nav className="mr-auto" navbar>
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                </NavItem>
                <UncontrolledDropdown nav inNavbar>
                  <DropdownToggle nav caret>
                    Lectors
                  </DropdownToggle>
                  <DropdownMenu right>                    
                      <Link to={'/lectors/new'}><DropdownItem>New</DropdownItem></Link>
                      <Link to={'/lectors'}><DropdownItem>List</DropdownItem></Link>                    
                  </DropdownMenu>
                </UncontrolledDropdown>
                <UncontrolledDropdown nav inNavbar>
                  <DropdownToggle nav caret>
                    Groups
                  </DropdownToggle>
                  <DropdownMenu right>                   
                      <Link to={'/groups/new'}> <DropdownItem>New</DropdownItem></Link>
                      <Link to={'/groups'}><DropdownItem>List</DropdownItem></Link>                    
                  </DropdownMenu>
                </UncontrolledDropdown>
                <UncontrolledDropdown nav inNavbar>
                  <DropdownToggle nav caret>
                    Specialities
                  </DropdownToggle>
                  <DropdownMenu right>                    
                      <Link to={'/specialities/new'}><DropdownItem>New</DropdownItem></Link>                                      
                      <Link to={'/specialities'}><DropdownItem>List</DropdownItem></Link>                    
                  </DropdownMenu>
                </UncontrolledDropdown>
                <UncontrolledDropdown nav inNavbar>
                  <DropdownToggle nav caret>
                    Subjects
                  </DropdownToggle>
                  <DropdownMenu right>                   
                      <Link to={'/subjects/new'}><DropdownItem>New</DropdownItem></Link>                                       
                      <Link to={'/subjects'}><DropdownItem>List</DropdownItem></Link>                    
                  </DropdownMenu>
                </UncontrolledDropdown>
              </Nav>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}
