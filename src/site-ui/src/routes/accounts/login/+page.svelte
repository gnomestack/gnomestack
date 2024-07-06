
<script lang="ts">
    import * as Card from '$lib/components/ui/card';
    import * as Tabs from '$lib/components/ui/tabs';
    import Button from '$lib/components/ui/button/button.svelte';
    import Input from '$lib/components/ui/input/input.svelte';
    import Label from '$lib/components/ui/label/label.svelte';
    import { getContext } from 'svelte';
    import { onMount } from 'svelte';
    import { login as loginUrl } from '../../../endpoints';
    onMount(() => {
        console.log('mounted');
    });

    const user = getContext('user') as UserStore;
    let email = '';
    let password = '';

    async function login() {
        await fetch(loginUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password })
        })
        .then(async r =>  {
            if (!r.ok) {
                const e = r.json();
                console.error(e);
                return 
            }

            const data = await r.json();
            console.log(data);
        })   
        .catch((error) => {
            console.error('Error:', error);
        });
    }

    async function toggle() {
        const input = document.getElementById('password') as HTMLInputElement;
        if (input.type === 'password') {
            input.type = 'text';
        } else {
            input.type = 'password';
        }
    }

</script>



<svelte:head>
	<title>Login</title>
	<meta name="description" content="Svelte demo app" />
</svelte:head>

<section>
    <Tabs.Root value="login" class="w-[400px]">
        <Tabs.List class="grid w-full grid-cols-2">
          <Tabs.Trigger value="login">Login</Tabs.Trigger>
          <Tabs.Trigger value="register">Register</Tabs.Trigger>
        </Tabs.List>
        <Tabs.Content value="login">
          <Card.Root>
            <Card.Header>
              <Card.Title>Account</Card.Title>
              <Card.Description>
                Make changes to your account here. Click save when you're done.
              </Card.Description>
            </Card.Header>
            <Card.Content class="space-y-2">
              <div class="space-y-1">
                <Label for="name">Name</Label>
                <Input id="name" bind:value="{email}" />
              </div>
              <div class="space-y-1">
                <Label for="password">Password</Label>
                <Input id="password" type="password" bind:value="{password}" />
                <Button on:click="{toggle}">View</Button>
              </div>
            </Card.Content>
            <Card.Footer>
              <Button on:click="{login}">Save changes</Button>
            </Card.Footer>
          </Card.Root>
        </Tabs.Content>
        <Tabs.Content value="register">
          <Card.Root>
            <Card.Header>
              <Card.Title>Password</Card.Title>
              <Card.Description>
                Change your password here. After saving, you'll be logged out.
              </Card.Description>
            </Card.Header>
            <Card.Content class="space-y-2">
              <div class="space-y-1">
                <Label for="current">Current password</Label>
                <Input id="current" type="password" />
              </div>
              <div class="space-y-1">
                <Label for="new">New password</Label>
                <Input id="new" type="password" />
              </div>
            </Card.Content>
            <Card.Footer>
              <Button>Save password</Button>
            </Card.Footer>
          </Card.Root>
        </Tabs.Content>
      </Tabs.Root>
</section>

<style>
	section {
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;
		flex: 0.6;
	}
</style>