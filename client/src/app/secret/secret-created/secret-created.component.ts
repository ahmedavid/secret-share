import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Secret } from 'src/app/_models/interfaces';
import { SecretService } from 'src/app/_services/secret.service';
import {Clipboard} from '@angular/cdk/clipboard';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-secret-created',
  templateUrl: './secret-created.component.html',
  styleUrls: ['./secret-created.component.scss'],
})
export class SecretCreatedComponent implements OnInit {
  secret: Secret | undefined;
  secretLinkCopied = false

  constructor(
    private route: ActivatedRoute,
    private secretService: SecretService,
    private clipboard: Clipboard
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if(id) {
      this.secretService.getSecret(id).subscribe({
        next: secret => this.secret = secret
      })
      console.log(id);

      console.log(environment)

    }
  }

  copyToClipboard() {
    console.log(this.clipboard.copy(`http://client.davidahmadov.net/secret/view/`+this.secret?.id))
    this.secretLinkCopied = true
  }
}
