export interface Student {
  identification: number;
  name: string;
  lastName: string;
  email: string;
}

export interface ResponseApi {
  data: Student[];
}
export interface ResponseApiGet {
  data: StudentCourse[];
}

export interface StudentCourse {
  id: number;
  studentId: number;
  courseId: number;
  description: string;
}

export interface EventStudent {
  idStudent: number;
  OpenModal: boolean;
}
