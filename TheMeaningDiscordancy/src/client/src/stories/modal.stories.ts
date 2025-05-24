import { MAT_DIALOG_DATA, MatDialog, MatDialogModule, MatDialogRef } from "@angular/material/dialog";
import { Meta, moduleMetadata, StoryObj } from "@storybook/angular";
import { ModalComponent } from "src/app/shared/components/modal/modal.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

const meta: Meta<ModalComponent> = {
    title: 'Modals/Modal',
    component: ModalComponent,
    decorators: [
        moduleMetadata({
            declarations: [],
            imports: [MatDialogModule, BrowserAnimationsModule],            
            providers: [
                { provide: MatDialogRef, useValue: { close: () => console.log('Mock close') } },
                { provide: MAT_DIALOG_DATA, useValue: { title: 'Storybook Modal', content: 'Test content!' } }
            ]
        }),
    ],
};

export default meta;

type Story = StoryObj<ModalComponent>;


export const Default: Story = {};