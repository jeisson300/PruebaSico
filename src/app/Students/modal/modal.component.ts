import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { StudentCourse } from 'src/app/interface/student.interface';
import { GeneralServices } from 'src/app/services/general.service';
import { __classPrivateFieldGet } from 'tslib';
import { EventStudent } from '../../interface/student.interface';
import { Subscription } from 'rxjs';
import { environment } from 'src/app/environments/environment';

@Component({
  selector: 'app-student-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css'],
})
export class ModalComponent {
  public studentCourseOwn: StudentCourse[] = [];
  public studentCourseNoOwn: StudentCourse[] = [];
  event: EventStudent = { OpenModal: true, idStudent: 0 };

  @ViewChild('modal')
  public dialog!: ElementRef<HTMLDialogElement>;

  constructor(private generalServices: GeneralServices) {}

  ngOnInit() {
    this.generalServices.openModal.subscribe((response: EventStudent) => {
      this.event = response;
      this.loadStudentCourse();
    });
  }
  public async loadStudentCourse() {
    const data = await this.generalServices.sendPetionGet(
      `${environment.baseUrl}/GetAllCoursesOwn/${this.event.idStudent}`
    );
    this.studentCourseOwn = data;

    const data2 = await this.generalServices.sendPetionGet(
      `${environment.baseUrl}/GetAllCoursesNoOwn/${this.event.idStudent}`
    );
    this.studentCourseNoOwn = data2;
    this.dialog.nativeElement.showModal();
  }

  public async handleCreateStudentCourse(courseId: number) {
    const data2 = await this.generalServices.sendPetionPost(
      `${environment.baseUrl}/CreateStudentCourse`,
      {
        courseId,
        studentId: this.event.idStudent,
      }
    );
    await this.loadStudentCourse();
  }

  public async handleDeleteStudenCourse(id: number) {
    const data2 = await this.generalServices.sendPetionDelete(
      `${environment.baseUrl}/deleteStudentCourse/${id}`
    );
    await this.loadStudentCourse();
  }
  handleCloseModal() {
    this.dialog.nativeElement.close();
  }
}
