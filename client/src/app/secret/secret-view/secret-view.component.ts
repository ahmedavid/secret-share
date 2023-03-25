import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Secret } from 'src/app/_models/interfaces';
import { SecretService } from 'src/app/_services/secret.service';

@Component({
  selector: 'app-secret-view',
  templateUrl: './secret-view.component.html',
  styleUrls: ['./secret-view.component.scss'],
})
export class SecretViewComponent implements OnInit {
  secret: Secret | undefined;
  constructor(
    private secretService: SecretService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id')
    if(id) {
      this.secretService.getSecret(id).subscribe({
        next: secret => this.secret = secret,
        error: error => {
          console.log(error)
          this.router.navigateByUrl("/not-found")
        }
      });
    }
  }
}
