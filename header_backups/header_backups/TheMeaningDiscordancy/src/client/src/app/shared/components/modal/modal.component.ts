import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'discord-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss']
})
export class ModalComponent {
  public filename: string = 'No file uploaded...';
  public userInput: string = 'Hello i am input';

  constructor(
    public dialogRef: MatDialogRef<ModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;

    if (input?.files?.length){
      const file: File = input.files[0];
    }
  }

  onCancel(): void {
    this.dialogRef.close(null);
  }

  onOk(): void {
    this.dialogRef.close(this.userInput);
  }
}
