import React, { Component } from 'react';
import { Button, Modal as RSModal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

export default class Modal extends Component {
    render() {
        const { modal, toggle, header, body } = this.props;

        return (<RSModal isOpen={modal} toggle={toggle}>
            <ModalHeader toggle={toggle}>{header}</ModalHeader>
            <ModalBody>
                {body}
            </ModalBody>
            <ModalFooter>
                <Button outline onClick={toggle} color="info">Close</Button>
            </ModalFooter>
        </RSModal>);
    }
};