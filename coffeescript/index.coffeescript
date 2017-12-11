MESSAGES = []
MESSAGES.push delay:0,    text:"Incoming transmission..."
MESSAGES.push delay:1200, text:"You don't talk to anybody."
MESSAGES.push delay:2200, text:"You don't interact with anybody."
MESSAGES.push delay:3600, text:"Your whole sense of reality is, pretty warped..."
MESSAGES.push delay:5200, text:"Does it bother you that we're not real?"

$container = $("#container")
$message = $("#message")
$animate = $("#animate")
$paragraph = null

scramble = (element, text, options) ->

  # Default properties.
  defaults =
    probability: 0.2
    glitches: '-|/\\'
    blank: ''
    duration: text.length * 40
    ease: 'easeInOutQuad'
    delay: 0.0

  # Convert the element to a jQuery object and build the settings object.
  $element = $(element)
  settings = $.extend defaults, options

  # Convenience methods.
  shuffle = () -> if Math.random() < 0.5 then 1 else -1
  wrap = (text, classes) -> """<span class="#{classes}">#{text}</span>"""

  # Glitch values.
  glitchText = settings.glitches
  glitchCharacters = glitchText.split ''
  glitchLength = glitchCharacters.length
  glitchProbability = settings.probability
  glitches = ((wrap letter, 'glitch') for letter in glitchCharacters)

  # Ghost values.
  ghostText = $element.text()
  ghostCharacters = ghostText.split ''
  ghostLength = ghostCharacters.length
  ghosts = ((wrap letter, 'ghost') for letter in ghostCharacters)

  # Text values.
  textCharacters = text.split ''
  textLength = textCharacters.length

  # Order and output arrays.
  order = [0...textLength].sort @shuffle
  output = []

  # Build the output array.
  for i in [0...textLength]
    glitchIndex = Math.floor Math.random() * (glitchLength - 1)
    glitchCharacter = glitches[glitchIndex]
    ghostCharacter = ghosts[i] or settings.blank
    addGlitch = Math.random() < glitchProbability
    character = if addGlitch then glitchCharacter else ghostCharacter
    output.push character

  # Animate the text.
  object = value:0
  target = value:1
  parameters =
    duration:settings.duration
    ease:settings.ease
    step: ->
      progress = Math.floor object.value * (textLength - 1)
      for i in [0..progress]
        index = order[i]
        output[index] = textCharacters[index]
      $element.html output.join ''
    complete: ->
      $element.html text

  # Animate the text.
  $(object).delay(settings.delay).animate target, parameters



animate = () ->
  for data, index in MESSAGES
    element = $paragraph.get index
    element.innerText = ''
    options = delay: data.delay
    scramble element, data.text, options
  return

initialise = () ->
  $animate.click animate
  $message.append "<p>" for text, index in MESSAGES
  $paragraph = $container.find "p"
  animate()
  return

initialise()
