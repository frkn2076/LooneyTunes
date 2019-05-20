
<p align="center">
  <img src="https://github.com/frkn2076/LooneyTunes/blob/master/Art/Bugs_Bunny.png">
</p>

<h1 align="center">GraphQL Looney Tunes</h1>
<p align="center">
  Get information of a Looney Tunes with GraphQL!<br />
</p>

## How to use

Simply get Looney Tunes Characters' information through queries in GraphQL, here are a few examples

```javascript
{
  cartoons {
    cartoonId,
    name,
    image,
    description
  }
}
```

```javascript
{
  cartoon(id:5) {
  cartoonId,
  name,
  image,
  description
  }
}
```

```javascript
{
  cartoon (name:"Bugs Bunny"){
    cartoonId,
    name,
    image,
    description
  }
}

```
## Shared Endpoint

```javascript
https://cartoonworlds.azurewebsites.net/graphql/
```
