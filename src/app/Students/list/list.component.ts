import { EventStudent } from './../../interface/student.interface';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Student } from 'src/app/interface/student.interface';
import { GeneralServices } from '../../services/general.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'],
})
export class ListComponent {
  constructor(private generalServices: GeneralServices) {}

  @Input()
  public ListStudent: Student[] = [];

  public handleStudentCourse(id: number) {
    const event: EventStudent = { OpenModal: true, idStudent: id };
    this.generalServices.hanldeModal(event);
  }
}
