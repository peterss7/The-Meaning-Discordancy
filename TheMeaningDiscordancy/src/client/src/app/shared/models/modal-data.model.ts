export class ModalData {
    public isModalOpen: boolean = false;
    public modalType: string = '';

    constructor(isModalOpen: boolean = false, modalType: string = '') {
        this.isModalOpen = isModalOpen;
        this.modalType = modalType;
    }
}