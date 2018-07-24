import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class IssueService {

  uri = 'https://localhost:5001';

  constructor(private http: HttpClient) {
  }

  getIssues() {
    return this.http.get(`${this.uri}/api/issues`);
  }

  getIssueById(id) {
    return this.http.get(`${this.uri}/api/issues/${id}`);
  }

  addIssue(title, responsible, description, severity) {
    const issue = {
      title: title,
      responsible: responsible,
      description: description,
      severity: severity
    };
    return this.http.post(`${this.uri}/api/issues/`, issue);
  }

  updateIssue(id, title, responsible, description, severity, status) {
    const issue = {
      title: title,
      responsible: responsible,
      description: description,
      severity: severity,
      status: status
    };
    return this.http.put(`${this.uri}/api/issues/${id}`, issue);
  }

  deleteIssue(id) {
    return this.http.delete(`${this.uri}/api/issues/${id}`);
  }
}