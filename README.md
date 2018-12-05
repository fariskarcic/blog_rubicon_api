# blog_rubicon_api

### Setup:
This project has been developed on .NET Core 2.1 SDK using VS Code, so the first thing you should do is: 
```json
dotnet restore
 ```

 For data I've implemented faker factory with which db can be populated, but before that if db file "blog.db" is not present its created with:
 ```json
 dotnet ef database update
 ```

 Then you just do:
 - URL: /api/tags?amount={int}
 - METHOD: POST

 Response should be boolean value.

 ### Posts API:
 ### 1. Get All(with filter):
 - URL: /api/posts
 - Optional filter: ?tag=
 - METHOD: GET
 - Notice: Title turning into slugs works properly, jsut couldnt manage to do it with faker

 - RESPONSE FORMAT:
 ```json
{
    "blogPosts": [
        {
            "slug": "doloribus-at-placeat",
            "title": "Adipisci et delectus omnis perspiciatis qui dolorem voluptas quod maiores.",
            "description": "Rerum non magnam ut neque fuga dolores saepe beatae quas.\nNon officia ut corporis et et.",
            "body": "Qui veniam accusamus. Eum nesciunt exercitationem aliquam accusamus non quis consequatur. Amet qui rerum nobis omnis rem sunt tempore accusamus corporis.",
            "tags": [
                "omnis",
                "maiores"
            ],
            "createdAt": "2018-12-04T22:48:29.8428709",
            "updatedAt": "2018-12-05T23:07:48.3506495"
        },
        {
            "slug": "nobis-beatae-aut",
            "title": "Reprehenderit et ut non laudantium qui quis et qui sit.",
            "description": "Vel accusamus consequatur ut soluta temporibus dolores iusto quod.\nDeserunt et qui.",
            "body": "Ea eos voluptatibus ipsam quaerat asperiores. Inventore quia voluptate iure sint ducimus magni. Ut error aut repudiandae.",
            "tags": [
                "excepturi",
                "omnis"
            ],
            "createdAt": "2018-12-05T09:52:54.5455265",
            "updatedAt": "2018-12-06T04:56:29.2419466"
        }
    ],
    "postsCount": 2
}
 ```

 ### 2. Get one(by slug):
- URL: /api/posts/{slug}
- METHOD: GET

- RESPONSE FORMAT:
```json
{
    "slug": "doloribus-at-placeat",
    "title": "Adipisci et delectus omnis perspiciatis qui dolorem voluptas quod maiores.",
    "description": "Rerum non magnam ut neque fuga dolores saepe beatae quas.\nNon officia ut corporis et et.",
    "body": "Qui veniam accusamus. Eum nesciunt exercitationem aliquam accusamus non quis consequatur. Amet qui rerum nobis omnis rem sunt tempore accusamus corporis.",
    "tags": [
        "maiores",
        "omnis"
    ],
    "createdAt": "2018-12-04T22:48:29.8428709",
    "updatedAt": "2018-12-05T23:07:48.3506495"
}
```

### 3. Post:
- URL: /api/posts
- METHOD: POST

- REQUEST FORMAT:
```json
{
	"title": "Title",
	"description": "Description",
	"body": "Body",
	"tags": ["Tag1", "Tag2"]
}
```

### 4. Update:
- URL: /api/posts/{slug}
- METHOD: PUT

- REQUEST FORMAT:
```json
{
	"title": "Title",
	"description": "Description",
	"body": "Body"
}
```

### 5. Remove:
- URL: /api/posts/{slug}
- METHOD: DELETE

- RESPONSE FORMAT:
```json
{
    "message": "Successfully removed post"
}
```

### Tags API:
### Get All:
- URL: /api/tags
- METHOD: GET

- RESPONSE FORMAT:
```json
{
    "tags": [
        "quas",
        "consectetur",
        "ducimus",
        "et",
        "ut",
        "facere",
        "quisquam",
        "maiores",
        "omnis",
        "excepturi",
        "ut",
        "doloremque",
        "tempore",
        "aut",
        "saepe",
        "nostrum",
        "id",
        "beatae",
        "earum",
        "porro",
        "est"
    ]
}
```

 