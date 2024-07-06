// See https://kit.svelte.dev/docs/types#app
// for information about these interfaces
import type { Writable } from 'svelte/store';
declare global {
	namespace App {
		// interface Error {}
		// interface Locals {}
		// interface PageData {}
		// interface PageState {}
		// interface Platform {}
	}

    interface UserStore extends Writable<null> {

    }
}

export {};
