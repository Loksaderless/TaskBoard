import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowSprintComponent } from './show-sprint.component';

describe('ShowSprintComponent', () => {
  let component: ShowSprintComponent;
  let fixture: ComponentFixture<ShowSprintComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ShowSprintComponent]
    });
    fixture = TestBed.createComponent(ShowSprintComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
